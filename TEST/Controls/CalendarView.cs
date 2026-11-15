using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace TEST.Controls
{
    /// <summary>Un élément affiché dans le calendrier (ici : une consultation).</summary>
    public class CalendrierEvenement
    {
        public int Id { get; set; }
        public DateTime Debut { get; set; }
        public string Titre { get; set; }
        public string Detail { get; set; }

        /// <summary>Sert à choisir la couleur (ici : l'id du médecin).</summary>
        public int Groupe { get; set; }
    }

    public class CalendrierEventArgs : EventArgs
    {
        public CalendrierEventArgs(int? id, DateTime date)
        {
            Id = id;
            Date = date;
        }

        public int? Id { get; private set; }
        public DateTime Date { get; private set; }
    }

    /// <summary>
    /// Calendrier mensuel : une case par jour, les événements sous forme de pastilles colorées.
    /// Clic sur une pastille : <see cref="EvenementClique"/> ; clic sur un jour : <see cref="JourClique"/>.
    /// </summary>
    [DefaultEvent("EvenementClique")]
    public class CalendarView : Control
    {
        private const int HauteurEntete = 52;
        private const int HauteurJours = 30;
        private const int HauteurPastille = 19;
        private const int EcartPastille = 2;
        private const int HautPastilles = 30;

        private static readonly Color[] Couleurs =
        {
            Theme.Primary, Theme.Violet, Theme.Success, Theme.Warning, Theme.Danger, Color.FromArgb(13, 148, 136)
        };

        private static readonly Color[] CouleursDouces =
        {
            Theme.PrimarySoft, Theme.VioletSoft, Theme.SuccessSoft, Theme.WarningSoft, Theme.DangerSoft,
            Color.FromArgb(204, 251, 241)
        };

        private readonly List<CalendrierEvenement> evenements = new List<CalendrierEvenement>();
        private readonly List<KeyValuePair<Rectangle, CalendrierEvenement>> zonesPastilles =
            new List<KeyValuePair<Rectangle, CalendrierEvenement>>();
        private readonly List<KeyValuePair<Rectangle, DateTime>> zonesPlus =
            new List<KeyValuePair<Rectangle, DateTime>>();
        private readonly ToolTip infobulle = new ToolTip();
        private ToolStripDropDown popupJour;

        private DateTime mois = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        private int? selection;
        private Point souris = new Point(-1, -1);
        private CalendrierEvenement survolPastille;
        private Rectangle zonePrecedent, zoneAujourdhui, zoneSuivant;

        public event EventHandler<CalendrierEventArgs> EvenementClique;
        public event EventHandler<CalendrierEventArgs> JourClique;
        public event EventHandler MoisChange;

        public CalendarView()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            BackColor = Theme.Surface;
            Font = Theme.Font(9F);
            Size = new Size(600, 480);
            infobulle.InitialDelay = 300;
        }

        /// <summary>Mois affiché (ramené au 1er du mois).</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Mois
        {
            get { return mois; }
            set
            {
                DateTime m = new DateTime(value.Year, value.Month, 1);
                if (m == mois)
                {
                    return;
                }
                mois = m;
                Invalidate();
                EventHandler h = MoisChange;
                if (h != null)
                {
                    h(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>Id de l'événement mis en évidence, ou null.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? Selection
        {
            get { return selection; }
            set { selection = value; Invalidate(); }
        }

        public void DefinirEvenements(IEnumerable<CalendrierEvenement> liste)
        {
            evenements.Clear();
            evenements.AddRange(liste);
            evenements.Sort(delegate(CalendrierEvenement a, CalendrierEvenement b) { return a.Debut.CompareTo(b.Debut); });
            Invalidate();
        }

        /// <summary>Nombre d'événements dans le mois affiché.</summary>
        public int NombreDansLeMois()
        {
            int n = 0;
            foreach (CalendrierEvenement e in evenements)
            {
                if (e.Debut.Year == mois.Year && e.Debut.Month == mois.Month)
                {
                    n++;
                }
            }
            return n;
        }

        // --- Géométrie ---

        private DateTime PremierJourAffiche
        {
            // Les semaines commencent le lundi.
            get { return mois.AddDays(-(((int)mois.DayOfWeek + 6) % 7)); }
        }

        private RectangleF ZoneGrille
        {
            get
            {
                float haut = HauteurEntete + HauteurJours;
                return new RectangleF(0, haut, Width - 1, Height - haut - 1);
            }
        }

        private Rectangle Case(int index)
        {
            RectangleF g = ZoneGrille;
            float l = g.Width / 7f;
            float h = g.Height / 6f;
            int col = index % 7;
            int ligne = index / 7;
            int x = (int)(g.X + col * l);
            int y = (int)(g.Y + ligne * h);
            return new Rectangle(x, y, (int)(g.X + (col + 1) * l) - x, (int)(g.Y + (ligne + 1) * h) - y);
        }

        private int CaseSous(Point p)
        {
            RectangleF g = ZoneGrille;
            if (!g.Contains(p))
            {
                return -1;
            }
            int col = Math.Min(6, (int)((p.X - g.X) / (g.Width / 7f)));
            int ligne = Math.Min(5, (int)((p.Y - g.Y) / (g.Height / 6f)));
            return ligne * 7 + col;
        }

        // --- Dessin ---

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BackColor);
            zonesPastilles.Clear();
            zonesPlus.Clear();

            DessinerEntete(g);
            DessinerJoursSemaine(g);

            DateTime premier = PremierJourAffiche;
            int caseSurvol = CaseSous(souris);
            for (int i = 0; i < 42; i++)
            {
                DessinerCase(g, i, premier.AddDays(i), i == caseSurvol);
            }

            // Quadrillage
            using (Pen stylo = new Pen(Theme.Border))
            {
                RectangleF grille = ZoneGrille;
                for (int c = 0; c <= 7; c++)
                {
                    float x = grille.X + c * grille.Width / 7f;
                    g.DrawLine(stylo, x, grille.Y, x, grille.Bottom);
                }
                for (int l = 0; l <= 6; l++)
                {
                    float y = grille.Y + l * grille.Height / 6f;
                    g.DrawLine(stylo, grille.X, y, grille.Right, y);
                }
            }
        }

        private void DessinerEntete(Graphics g)
        {
            string titre = mois.ToString("MMMM yyyy");
            titre = char.ToUpper(titre[0]) + titre.Substring(1);
            TextRenderer.DrawText(g, titre, Theme.Semibold(14F), new Rectangle(0, 0, Width / 2, 42), Theme.Text,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);

            zoneSuivant = new Rectangle(Width - 38, 4, 38, 34);
            zoneAujourdhui = new Rectangle(zoneSuivant.X - 8 - 112, 4, 112, 34);
            zonePrecedent = new Rectangle(zoneAujourdhui.X - 8 - 38, 4, 38, 34);

            DessinerBouton(g, zonePrecedent, "", true);
            DessinerBouton(g, zoneAujourdhui, "Aujourd'hui", false);
            DessinerBouton(g, zoneSuivant, "", true);
        }

        private void DessinerBouton(Graphics g, Rectangle r, string texte, bool icone)
        {
            bool survol = r.Contains(souris);
            using (GraphicsPath forme = Formes.Arrondi(r, 6))
            {
                using (SolidBrush fond = new SolidBrush(survol ? Theme.Background : Theme.Surface))
                {
                    g.FillPath(fond, forme);
                }
                using (Pen stylo = new Pen(Theme.BorderStrong))
                {
                    g.DrawPath(stylo, forme);
                }
            }
            TextRenderer.DrawText(g, texte, icone ? Theme.Icon(10F) : Theme.Semibold(9.5F), r, Theme.Text,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void DessinerJoursSemaine(Graphics g)
        {
            string[] noms = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
            RectangleF grille = ZoneGrille;
            using (SolidBrush fond = new SolidBrush(Theme.SurfaceHover))
            {
                g.FillRectangle(fond, 0, HauteurEntete, Width - 1, HauteurJours);
            }
            for (int c = 0; c < 7; c++)
            {
                string nom = noms[(c + 1) % 7].TrimEnd('.').ToUpper();
                Rectangle r = new Rectangle((int)(grille.X + c * grille.Width / 7f), HauteurEntete,
                    (int)(grille.Width / 7f), HauteurJours);
                TextRenderer.DrawText(g, nom, Theme.Semibold(8.5F), r, Theme.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void DessinerCase(Graphics g, int index, DateTime jour, bool survol)
        {
            Rectangle r = Case(index);
            bool dansLeMois = jour.Month == mois.Month;
            bool aujourdhui = jour == DateTime.Today;

            Color fond = !dansLeMois ? Theme.SurfaceHover : survol && survolPastille == null ? Theme.Background : Theme.Surface;
            using (SolidBrush pinceau = new SolidBrush(fond))
            {
                g.FillRectangle(pinceau, r);
            }

            // Numéro du jour (pastille bleue pour aujourd'hui)
            Rectangle num = new Rectangle(r.X + 6, r.Y + 5, 24, 24);
            if (aujourdhui)
            {
                using (SolidBrush rond = new SolidBrush(Theme.Primary))
                {
                    g.FillEllipse(rond, num);
                }
            }
            TextRenderer.DrawText(g, jour.Day.ToString(), aujourdhui ? Theme.Semibold(9F) : Theme.Font(9F), num,
                aujourdhui ? Color.White : dansLeMois ? Theme.Text : Theme.TextDisabled,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Pastilles des événements du jour
            List<CalendrierEvenement> duJour = new List<CalendrierEvenement>();
            foreach (CalendrierEvenement ev in evenements)
            {
                if (ev.Debut.Date == jour)
                {
                    duJour.Add(ev);
                }
            }
            if (duJour.Count == 0)
            {
                return;
            }

            int y = r.Y + HautPastilles;
            int place = Math.Max(1, (r.Bottom - 3 - y + EcartPastille) / (HauteurPastille + EcartPastille));
            int affiches = duJour.Count <= place ? duJour.Count : place - 1;

            // Case trop petite pour une pastille + « +N » : une seule pastille récapitulative.
            if (affiches == 0)
            {
                Rectangle resume = new Rectangle(r.X + 4, y, r.Width - 8, HauteurPastille);
                bool survolResume = resume.Contains(souris);
                using (GraphicsPath forme = Formes.Arrondi(resume, 4))
                using (SolidBrush pinceau = new SolidBrush(survolResume ? Theme.Primary : Theme.PrimarySoft))
                {
                    g.FillPath(pinceau, forme);
                }
                TextRenderer.DrawText(g, duJour.Count + " consult.", Theme.Semibold(8.5F), resume,
                    survolResume ? Color.White : Theme.PrimaryPressed,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                zonesPlus.Add(new KeyValuePair<Rectangle, DateTime>(resume, jour));
                return;
            }

            for (int i = 0; i < affiches; i++)
            {
                CalendrierEvenement ev = duJour[i];
                Rectangle p = new Rectangle(r.X + 4, y, r.Width - 8, HauteurPastille);
                DessinerPastille(g, p, ev, dansLeMois);
                zonesPastilles.Add(new KeyValuePair<Rectangle, CalendrierEvenement>(p, ev));
                y += HauteurPastille + EcartPastille;
            }

            int reste = duJour.Count - affiches;
            if (reste > 0)
            {
                Rectangle plus = new Rectangle(r.X + 4, y, r.Width - 8, HauteurPastille);
                TextRenderer.DrawText(g, "+" + reste + (reste > 1 ? " autres" : " autre"), Theme.Semibold(8.5F),
                    new Rectangle(plus.X + 4, plus.Y, plus.Width - 4, plus.Height),
                    plus.Contains(souris) ? Theme.Primary : Theme.TextMuted,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                zonesPlus.Add(new KeyValuePair<Rectangle, DateTime>(plus, jour));
            }
        }

        private void DessinerPastille(Graphics g, Rectangle p, CalendrierEvenement ev, bool dansLeMois)
        {
            int k = Math.Abs(ev.Groupe) % Couleurs.Length;
            bool choisi = selection.HasValue && selection.Value == ev.Id;
            bool survol = survolPastille == ev;
            Color accent = Couleurs[k];
            Color fond = choisi ? accent : survol ? ControlPaint.Light(CouleursDouces[k], -0.05f) : CouleursDouces[k];
            if (!dansLeMois && !choisi)
            {
                fond = Theme.Background;
            }

            using (GraphicsPath forme = Formes.Arrondi(p, 4))
            using (SolidBrush pinceau = new SolidBrush(fond))
            {
                g.FillPath(pinceau, forme);
            }
            if (!choisi)
            {
                using (SolidBrush barre = new SolidBrush(accent))
                {
                    g.FillRectangle(barre, p.X, p.Y + 3, 3, p.Height - 6);
                }
            }

            Color texte = choisi ? Color.White : Theme.Text;
            Rectangle zoneHeure = new Rectangle(p.X + 8, p.Y, 38, p.Height);
            TextRenderer.DrawText(g, ev.Debut.ToString("HH:mm"), Theme.Semibold(8.5F), zoneHeure,
                choisi ? Color.White : accent, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            TextRenderer.DrawText(g, ev.Titre, Theme.Font(8.5F),
                new Rectangle(p.X + 46, p.Y, p.Width - 50, p.Height), texte,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                TextFormatFlags.SingleLine | TextFormatFlags.NoPadding);
        }

        // --- Souris ---

        private CalendrierEvenement PastilleSous(Point p)
        {
            foreach (KeyValuePair<Rectangle, CalendrierEvenement> z in zonesPastilles)
            {
                if (z.Key.Contains(p))
                {
                    return z.Value;
                }
            }
            return null;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            souris = e.Location;
            CalendrierEvenement p = PastilleSous(e.Location);
            if (p != survolPastille)
            {
                survolPastille = p;
                infobulle.SetToolTip(this, p == null ? null :
                    p.Debut.ToString("dddd d MMMM · HH:mm") + "\n" + p.Titre + "\n" + p.Detail);
            }
            bool main = p != null || zonePrecedent.Contains(e.Location) || zoneSuivant.Contains(e.Location) ||
                        zoneAujourdhui.Contains(e.Location) || CaseSous(e.Location) >= 0;
            Cursor = main ? Cursors.Hand : Cursors.Default;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            souris = new Point(-1, -1);
            survolPastille = null;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            if (zonePrecedent.Contains(e.Location)) { Mois = mois.AddMonths(-1); return; }
            if (zoneSuivant.Contains(e.Location)) { Mois = mois.AddMonths(1); return; }
            if (zoneAujourdhui.Contains(e.Location)) { Mois = DateTime.Today; return; }

            CalendrierEvenement p = PastilleSous(e.Location);
            if (p != null)
            {
                SignalerEvenement(p);
                return;
            }

            foreach (KeyValuePair<Rectangle, DateTime> z in zonesPlus)
            {
                if (z.Key.Contains(e.Location))
                {
                    OuvrirJour(z.Value, z.Key);
                    return;
                }
            }

            int c = CaseSous(e.Location);
            if (c >= 0)
            {
                EventHandler<CalendrierEventArgs> h = JourClique;
                if (h != null)
                {
                    h(this, new CalendrierEventArgs(null, PremierJourAffiche.AddDays(c)));
                }
            }
        }

        private void SignalerEvenement(CalendrierEvenement ev)
        {
            EventHandler<CalendrierEventArgs> h = EvenementClique;
            if (h != null)
            {
                h(this, new CalendrierEventArgs(ev.Id, ev.Debut));
            }
        }

        /// <summary>Élément de la liste du jour (texte affiché : heure, patient, détail).</summary>
        private class ElementJour
        {
            public CalendrierEvenement Evenement;

            public override string ToString()
            {
                return Evenement.Debut.ToString("HH:mm") + "    " + Evenement.Titre + "   ·   " + Evenement.Detail;
            }
        }

        /// <summary>Affiche toutes les consultations d'un jour dans une petite fenêtre sous la case.</summary>
        private void OuvrirJour(DateTime jour, Rectangle sous)
        {
            if (popupJour != null)
            {
                popupJour.Dispose();
            }

            Label titre = new Label();
            string texte = jour.ToString("dddd d MMMM");
            titre.Text = char.ToUpper(texte[0]) + texte.Substring(1);
            titre.Font = Theme.Semibold(10.5F);
            titre.ForeColor = Theme.Text;
            titre.BackColor = Theme.Surface;
            titre.Padding = new Padding(10, 0, 0, 0);
            titre.TextAlign = ContentAlignment.MiddleLeft;
            titre.Dock = DockStyle.Top;
            titre.Height = 36;

            ListePopup liste = new ListePopup();
            liste.Dock = DockStyle.Fill;
            foreach (CalendrierEvenement ev in evenements)
            {
                if (ev.Debut.Date == jour.Date)
                {
                    liste.Items.Add(new ElementJour { Evenement = ev });
                }
            }

            Panel contenu = new Panel();
            contenu.BackColor = Theme.Surface;
            contenu.Size = new Size(360, titre.Height + Math.Min(liste.Items.Count, 8) * liste.ItemHeight + 4);
            contenu.Controls.Add(liste);
            contenu.Controls.Add(titre);

            ToolStripControlHost host = new ToolStripControlHost(contenu);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = contenu.Size;

            popupJour = new ToolStripDropDown();
            popupJour.Padding = new Padding(1);
            popupJour.Items.Add(host);

            ToolStripDropDown popup = popupJour;
            liste.MouseUp += delegate(object s, MouseEventArgs ev)
            {
                int i = liste.IndexFromPoint(ev.Location);
                if (i >= 0)
                {
                    popup.Close();
                    SignalerEvenement(((ElementJour)liste.Items[i]).Evenement);
                }
            };

            popupJour.Show(this, new Point(Math.Min(sous.X, Math.Max(0, Width - contenu.Width - 4)), sous.Bottom + 2));
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            Mois = mois.AddMonths(e.Delta > 0 ? -1 : 1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                infobulle.Dispose();
                if (popupJour != null)
                {
                    popupJour.Dispose();
                }
            }
            base.Dispose(disposing);
        }
    }
}
