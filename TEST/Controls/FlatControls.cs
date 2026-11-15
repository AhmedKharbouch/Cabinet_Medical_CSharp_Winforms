using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Contrôles modernes écrits uniquement avec WinForms standard (aucune bibliothèque externe).
namespace TEST.Controls
{
    public enum ButtonVariant
    {
        Primary,
        Secondary,
        Danger,
        Ghost,
        Nav
    }

    /// <summary>Bouton plat arrondi avec variantes de couleur et icône optionnelle.</summary>
    public class FlatButton : Button
    {
        private ButtonVariant variant = ButtonVariant.Primary;
        private string iconGlyph = "";
        private bool selected;
        private int radius = 6;
        private bool survol;
        private bool appui;

        public FlatButton()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            Cursor = Cursors.Hand;
            Font = Theme.Semibold(10F);
            Size = new Size(120, 38);
            UseVisualStyleBackColor = false;
        }

        [Category("Apparence"), DefaultValue(ButtonVariant.Primary)]
        public ButtonVariant Variant { get { return variant; } set { variant = value; Invalidate(); } }

        [Category("Apparence"), DefaultValue("")]
        public string IconGlyph { get { return iconGlyph; } set { iconGlyph = value ?? ""; Invalidate(); } }

        /// <summary>Pour les boutons du menu : élément actif.</summary>
        [Category("Apparence"), DefaultValue(false)]
        public bool Selected { get { return selected; } set { selected = value; Invalidate(); } }

        [Category("Apparence"), DefaultValue(6)]
        public int Radius { get { return radius; } set { radius = Math.Max(0, value); Invalidate(); } }

        protected override void OnMouseEnter(EventArgs e) { survol = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { survol = false; appui = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { appui = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { appui = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }

        private void Couleurs(out Color fond, out Color bord, out Color texte)
        {
            Color parent = Parent != null ? Parent.BackColor : Theme.Surface;
            switch (variant)
            {
                case ButtonVariant.Secondary:
                    fond = appui ? Theme.Background : survol ? Theme.SurfaceHover : Theme.Surface;
                    bord = Theme.BorderStrong;
                    texte = Theme.Text;
                    break;
                case ButtonVariant.Danger:
                    fond = appui ? Theme.DangerBorder : survol ? Theme.DangerSoft : Theme.Surface;
                    bord = Theme.DangerBorder;
                    texte = Theme.Danger;
                    break;
                case ButtonVariant.Ghost:
                    fond = appui ? Theme.Border : survol ? Theme.Background : parent;
                    bord = Color.Empty;
                    texte = survol ? Theme.Text : Theme.TextMuted;
                    break;
                case ButtonVariant.Nav:
                    fond = selected ? Theme.Primary : survol ? Theme.SidebarHover : parent;
                    bord = Color.Empty;
                    texte = selected || survol ? Color.White : Theme.SidebarText;
                    break;
                default:
                    fond = appui ? Theme.PrimaryPressed : survol ? Theme.PrimaryHover : Theme.Primary;
                    bord = Color.Empty;
                    texte = Color.White;
                    break;
            }

            if (!Enabled)
            {
                if (variant == ButtonVariant.Nav || variant == ButtonVariant.Ghost)
                {
                    texte = Theme.TextDisabled;
                }
                else
                {
                    fond = Theme.Background;
                    bord = Theme.Border;
                    texte = Theme.TextDisabled;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : BackColor);

            Color fond, bord, texte;
            Couleurs(out fond, out bord, out texte);

            Rectangle zone = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath forme = Formes.Arrondi(zone, radius))
            {
                using (SolidBrush pinceau = new SolidBrush(fond))
                {
                    g.FillPath(pinceau, forme);
                }
                if (!bord.IsEmpty)
                {
                    using (Pen stylo = new Pen(bord))
                    {
                        g.DrawPath(stylo, forme);
                    }
                }
            }

            // Anneau de focus visible au clavier
            if (Focused && ShowFocusCues && variant != ButtonVariant.Nav)
            {
                Rectangle anneau = new Rectangle(1, 1, Width - 3, Height - 3);
                using (GraphicsPath p = Formes.Arrondi(anneau, Math.Max(0, radius - 1)))
                using (Pen stylo = new Pen(Theme.PrimarySoft, 2))
                {
                    g.DrawPath(stylo, p);
                }
            }

            DessinerContenu(g, texte);
        }

        private void DessinerContenu(Graphics g, Color couleur)
        {
            bool aIcone = iconGlyph.Length > 0;
            bool aTexte = !string.IsNullOrEmpty(Text);
            Font police = Font;
            Font icone = Theme.Icon(Math.Max(9F, police.Size + 1F));
            TextFormatFlags drapeaux = TextFormatFlags.VerticalCenter | TextFormatFlags.SingleLine |
                                       TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis;

            if (variant == ButtonVariant.Nav)
            {
                int x = 16;
                if (aIcone)
                {
                    TextRenderer.DrawText(g, iconGlyph, icone, new Rectangle(x, 0, 24, Height), couleur,
                        drapeaux | TextFormatFlags.HorizontalCenter);
                    x += 36;
                }
                TextRenderer.DrawText(g, Text, police, new Rectangle(x, 0, Width - x - 8, Height), couleur,
                    drapeaux | TextFormatFlags.Left);
                return;
            }

            // Mesure sans EndEllipsis : avec une taille vide, l'ellipse fausse la largeur mesurée.
            TextFormatFlags mesure = TextFormatFlags.SingleLine | TextFormatFlags.NoPadding;
            Size tTexte = aTexte ? TextRenderer.MeasureText(g, Text, police, Size.Empty, mesure) : Size.Empty;
            Size tIcone = aIcone ? TextRenderer.MeasureText(g, iconGlyph, icone, Size.Empty, mesure) : Size.Empty;
            int ecart = aIcone && aTexte ? 8 : 0;
            int largeur = tIcone.Width + ecart + tTexte.Width;
            int depart = Math.Max(4, (Width - largeur) / 2);

            if (aIcone)
            {
                TextRenderer.DrawText(g, iconGlyph, icone, new Rectangle(depart, 0, tIcone.Width + 2, Height),
                    couleur, drapeaux | TextFormatFlags.Left);
            }
            if (aTexte)
            {
                int x = depart + tIcone.Width + ecart;
                TextRenderer.DrawText(g, Text, police, new Rectangle(x, 0, Width - x - 4, Height), couleur,
                    drapeaux | TextFormatFlags.Left);
            }
        }
    }

    /// <summary>
    /// Zone de texte moderne : cadre arrondi, bordure bleue au focus,
    /// texte d'aide (placeholder) et icône optionnelle à gauche.
    /// </summary>
    [DefaultEvent("TextChanged")]
    public class FlatTextBox : UserControl
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private readonly TextBox interne = new TextBox();
        private string placeholder = "";
        private string iconGlyph = "";
        private bool focus;
        private bool erreur;

        public FlatTextBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.SupportsTransparentBackColor, true);

            interne.BorderStyle = BorderStyle.None;
            interne.BackColor = Theme.Surface;
            interne.ForeColor = Theme.Text;
            interne.Font = Theme.Font(10.5F);
            interne.TextChanged += delegate { Erreur = false; OnTextChanged(EventArgs.Empty); };
            interne.KeyPress += delegate(object s, KeyPressEventArgs e) { OnKeyPress(e); };
            interne.KeyDown += delegate(object s, KeyEventArgs e) { OnKeyDown(e); };
            interne.Enter += delegate { focus = true; Invalidate(); };
            interne.Leave += delegate { focus = false; Invalidate(); };
            interne.HandleCreated += delegate { AppliquerPlaceholder(); };
            Controls.Add(interne);

            BackColor = Color.Transparent;
            Size = new Size(240, 38);
            Cursor = Cursors.IBeam;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return interne.Text; }
            set { interne.Text = value; }
        }

        [Category("Apparence"), DefaultValue("")]
        public string Placeholder
        {
            get { return placeholder; }
            set { placeholder = value ?? ""; AppliquerPlaceholder(); }
        }

        [Category("Apparence"), DefaultValue("")]
        public string IconGlyph
        {
            get { return iconGlyph; }
            set { iconGlyph = value ?? ""; PerformLayout(); Invalidate(); }
        }

        [DefaultValue('\0')]
        public char PasswordChar { get { return interne.PasswordChar; } set { interne.PasswordChar = value; } }

        [DefaultValue(32767)]
        public int MaxLength { get { return interne.MaxLength; } set { interne.MaxLength = value; } }

        /// <summary>Affiche la bordure en rouge (champ invalide). Revient à la normale dès qu'on tape.</summary>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Erreur { get { return erreur; } set { erreur = value; Invalidate(); } }

        public void Clear()
        {
            interne.Clear();
        }

        public new void Focus()
        {
            interne.Focus();
        }

        private void AppliquerPlaceholder()
        {
            if (interne.IsHandleCreated)
            {
                SendMessage(interne.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            interne.Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            interne.Focus();
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            interne.BackColor = Enabled ? Theme.Surface : Theme.Background;
            Invalidate();
        }

        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            int gauche = iconGlyph.Length > 0 ? 36 : 12;
            interne.Width = Math.Max(10, Width - gauche - 12);
            interne.Location = new Point(gauche, Math.Max(0, (Height - interne.Height) / 2));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle zone = new Rectangle(0, 0, Width - 1, Height - 1);
            Color bord = erreur ? Theme.Danger : focus ? Theme.Primary : Theme.BorderStrong;

            using (GraphicsPath forme = Formes.Arrondi(zone, 6))
            {
                using (SolidBrush pinceau = new SolidBrush(interne.BackColor))
                {
                    g.FillPath(pinceau, forme);
                }
                using (Pen stylo = new Pen(bord, focus || erreur ? 1.6F : 1F))
                {
                    g.DrawPath(stylo, forme);
                }
            }

            if (iconGlyph.Length > 0)
            {
                TextRenderer.DrawText(g, iconGlyph, Theme.Icon(11F), new Rectangle(10, 0, 22, Height),
                    Theme.TextMuted, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
            }
        }
    }

    /// <summary>Liste aux éléments espacés, utilisée dans les menus déroulants.</summary>
    internal class ListePopup : ListBox
    {
        private int survol = -1;

        public ListePopup()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 34;
            BorderStyle = BorderStyle.None;
            IntegralHeight = false;
            Font = Theme.Font(10.5F);
            BackColor = Theme.Surface;
            BindingContext = new BindingContext();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            int i = IndexFromPoint(e.Location);
            if (i != survol)
            {
                survol = i;
                Invalidate();
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            survol = -1;
            Invalidate();
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }
            bool selection = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
            Color fond = selection ? Theme.PrimarySoft : e.Index == survol ? Theme.SurfaceHover : Theme.Surface;
            using (SolidBrush pinceau = new SolidBrush(fond))
            {
                e.Graphics.FillRectangle(pinceau, e.Bounds);
            }
            Rectangle r = new Rectangle(e.Bounds.X + 12, e.Bounds.Y, e.Bounds.Width - 16, e.Bounds.Height);
            TextRenderer.DrawText(e.Graphics, GetItemText(Items[e.Index]), selection ? Theme.Semibold(10.5F) : Font, r,
                selection ? Theme.PrimaryPressed : Theme.Text,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis);
        }
    }

    /// <summary>
    /// Base des champs à menu déroulant (liste, date) : cadre identique aux zones de texte,
    /// ouverture au clic, à la touche Entrée, Espace, F4 ou Alt+Bas.
    /// </summary>
    public abstract class ChampDeroulant : Control
    {
        protected readonly ToolStripDropDown popup = new ToolStripDropDown();
        protected readonly ToolStripControlHost host;
        private readonly Control contenu;
        private bool survol;
        private bool ouvert;
        private DateTime fermeLe = DateTime.MinValue;

        protected ChampDeroulant(Control contenuPopup)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw |
                     ControlStyles.Selectable | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            Font = Theme.Font(10.5F);
            Size = new Size(240, 40);
            Cursor = Cursors.Hand;
            TabStop = true;

            contenu = contenuPopup;
            host = new ToolStripControlHost(contenu);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            popup.Padding = new Padding(1);
            popup.Items.Add(host);
            popup.Closed += delegate
            {
                ouvert = false;
                fermeLe = DateTime.Now;
                Invalidate();
            };
        }

        /// <summary>Texte affiché dans le champ (vide = afficher le texte d'aide).</summary>
        protected abstract string TexteAffiche { get; }

        protected abstract string Glyphe { get; }

        [Category("Apparence"), DefaultValue("")]
        public string Placeholder { get; set; }

        /// <summary>Prépare le contenu juste avant l'ouverture ; renvoie false pour ne pas ouvrir.</summary>
        protected abstract bool PreparerOuverture();

        public void Ouvrir()
        {
            if (ouvert || !Enabled || !PreparerOuverture())
            {
                return;
            }
            host.Size = contenu.Size;
            ouvert = true;
            popup.Show(this, new Point(0, Height + 4));
            contenu.Focus();
            Invalidate();
        }

        public void Fermer()
        {
            popup.Close();
            Focus();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            // Un clic sur le champ pendant qu'il est ouvert ferme le menu : ne pas le rouvrir aussitôt.
            if ((DateTime.Now - fermeLe).TotalMilliseconds > 250)
            {
                Ouvrir();
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            Keys k = keyData & Keys.KeyCode;
            return k == Keys.Up || k == Keys.Down || base.IsInputKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyCode == Keys.F4 || e.KeyCode == Keys.Space || e.KeyCode == Keys.Enter ||
                (e.Alt && e.KeyCode == Keys.Down))
            {
                Ouvrir();
                e.Handled = true;
            }
        }

        protected override void OnMouseEnter(EventArgs e) { survol = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { survol = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnGotFocus(EventArgs e) { Invalidate(); base.OnGotFocus(e); }
        protected override void OnLostFocus(EventArgs e) { Invalidate(); base.OnLostFocus(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle zone = new Rectangle(0, 0, Width - 1, Height - 1);
            bool actif = Focused || ouvert;
            Color bord = actif ? Theme.Primary : survol ? Theme.TextDisabled : Theme.BorderStrong;

            using (GraphicsPath forme = Formes.Arrondi(zone, 6))
            {
                using (SolidBrush fond = new SolidBrush(Enabled ? Theme.Surface : Theme.Background))
                {
                    g.FillPath(fond, forme);
                }
                using (Pen stylo = new Pen(bord, actif ? 1.6F : 1F))
                {
                    g.DrawPath(stylo, forme);
                }
            }

            string texte = TexteAffiche;
            bool vide = string.IsNullOrEmpty(texte);
            TextRenderer.DrawText(g, vide ? (Placeholder ?? "") : texte, Font,
                new Rectangle(12, 0, Width - 48, Height),
                vide ? Theme.TextDisabled : (Enabled ? Theme.Text : Theme.TextDisabled),
                TextFormatFlags.VerticalCenter | TextFormatFlags.Left | TextFormatFlags.EndEllipsis |
                TextFormatFlags.SingleLine);
            TextRenderer.DrawText(g, Glyphe, Theme.Icon(10F), new Rectangle(Width - 36, 0, 28, Height),
                Theme.TextMuted, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                popup.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>Liste déroulante moderne (même API de liaison que ComboBox : DataSource, DisplayMember, ValueMember).</summary>
    [DefaultEvent("SelectedIndexChanged")]
    public class FlatComboBox : ChampDeroulant
    {
        private readonly ListePopup liste;

        public event EventHandler SelectedIndexChanged;

        public FlatComboBox() : this(new ListePopup())
        {
        }

        private FlatComboBox(ListePopup l) : base(l)
        {
            liste = l;
            Placeholder = "Sélectionner…";
            liste.MouseUp += delegate(object s, MouseEventArgs e)
            {
                int i = liste.IndexFromPoint(e.Location);
                if (i >= 0)
                {
                    liste.SelectedIndex = i;
                    Fermer();
                }
            };
            liste.KeyDown += delegate(object s, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                {
                    Fermer();
                    e.Handled = true;
                }
            };
            liste.SelectedIndexChanged += delegate
            {
                Invalidate();
                EventHandler h = SelectedIndexChanged;
                if (h != null)
                {
                    h(this, EventArgs.Empty);
                }
            };
        }

        protected override string TexteAffiche
        {
            get { return liste.SelectedIndex >= 0 ? liste.GetItemText(liste.SelectedItem) : ""; }
        }

        protected override string Glyphe
        {
            get { return ""; }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            get { return liste.DataSource; }
            set { liste.DataSource = value; liste.SelectedIndex = -1; Invalidate(); }
        }

        [DefaultValue("")]
        public string DisplayMember { get { return liste.DisplayMember; } set { liste.DisplayMember = value; } }

        [DefaultValue("")]
        public string ValueMember { get { return liste.ValueMember; } set { liste.ValueMember = value; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object SelectedValue
        {
            get { return liste.SelectedIndex >= 0 ? liste.SelectedValue : null; }
            set
            {
                if (value == null)
                {
                    liste.SelectedIndex = -1;
                }
                else
                {
                    liste.SelectedValue = value;
                }
                Invalidate();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SelectedIndex
        {
            get { return liste.SelectedIndex; }
            set { liste.SelectedIndex = value; Invalidate(); }
        }

        protected override bool PreparerOuverture()
        {
            int n = liste.Items.Count;
            if (n == 0)
            {
                return false;
            }
            liste.Size = new Size(Math.Max(120, Width - 2), Math.Min(n, 8) * liste.ItemHeight);
            if (liste.SelectedIndex >= 0)
            {
                liste.TopIndex = Math.Max(0, liste.SelectedIndex - 3);
            }
            return true;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Flèches haut/bas : change la sélection sans ouvrir la liste.
            if (!e.Alt && (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up) && liste.Items.Count > 0)
            {
                int i = liste.SelectedIndex + (e.KeyCode == Keys.Down ? 1 : -1);
                liste.SelectedIndex = Math.Max(0, Math.Min(liste.Items.Count - 1, i));
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }
    }

    /// <summary>
    /// Sélecteur de date et d'heure : un calendrier et une liste de créneaux (toutes les 15 minutes).
    /// </summary>
    [DefaultEvent("ValueChanged")]
    public class FlatDateTimePicker : ChampDeroulant
    {
        private readonly MonthCalendar calendrier;
        private readonly ListePopup heures;
        private DateTime valeur = DateTime.Now;
        private string format = "dddd d MMMM yyyy  ·  HH:mm";

        public event EventHandler ValueChanged;

        public FlatDateTimePicker() : this(new Panel())
        {
        }

        private FlatDateTimePicker(Panel contenu) : base(contenu)
        {
            Placeholder = "Choisir une date";
            contenu.BackColor = Theme.Surface;
            contenu.Padding = new Padding(8);

            calendrier = new MonthCalendar();
            calendrier.MaxSelectionCount = 1;
            calendrier.Location = new Point(8, 8);
            calendrier.DateSelected += delegate(object s, DateRangeEventArgs e)
            {
                Value = e.Start.Date + valeur.TimeOfDay;
            };

            heures = new ListePopup();
            heures.ItemHeight = 30;
            for (int m = 0; m < 24 * 60; m += 15)
            {
                heures.Items.Add(string.Format("{0:00}:{1:00}", m / 60, m % 60));
            }
            heures.Location = new Point(calendrier.Right + 8, 8);
            heures.Size = new Size(84, calendrier.Height);
            heures.MouseUp += delegate(object s, MouseEventArgs e)
            {
                int i = heures.IndexFromPoint(e.Location);
                if (i >= 0)
                {
                    Value = valeur.Date + TimeSpan.FromMinutes(i * 15);
                    Fermer();
                }
            };
            heures.KeyDown += delegate(object s, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter && heures.SelectedIndex >= 0)
                {
                    Value = valeur.Date + TimeSpan.FromMinutes(heures.SelectedIndex * 15);
                    Fermer();
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Fermer();
                }
            };

            contenu.Controls.Add(calendrier);
            contenu.Controls.Add(heures);
            contenu.Size = new Size(heures.Right + 8, calendrier.Bottom + 8);
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime Value
        {
            get { return valeur; }
            set
            {
                if (value == valeur)
                {
                    return;
                }
                valeur = value;
                Invalidate();
                EventHandler h = ValueChanged;
                if (h != null)
                {
                    h(this, EventArgs.Empty);
                }
            }
        }

        [Category("Apparence"), DefaultValue("dddd d MMMM yyyy  ·  HH:mm")]
        public string CustomFormat { get { return format; } set { format = value; Invalidate(); } }

        protected override string TexteAffiche
        {
            get
            {
                string s = valeur.ToString(format);
                return s.Length > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s;
            }
        }

        protected override string Glyphe
        {
            get { return ""; }
        }

        protected override bool PreparerOuverture()
        {
            // La taille réelle du calendrier n'est connue qu'une fois son handle créé.
            Control contenu = calendrier.Parent;
            contenu.CreateControl();
            calendrier.Size = calendrier.SingleMonthSize;
            heures.Location = new Point(calendrier.Right + 8, calendrier.Top);
            heures.Size = new Size(84, calendrier.Height);
            contenu.Size = new Size(heures.Right + 8, calendrier.Bottom + 8);

            calendrier.SetDate(valeur.Date);
            int i = (int)Math.Round(valeur.TimeOfDay.TotalMinutes / 15.0);
            i = Math.Max(0, Math.Min(heures.Items.Count - 1, i));
            heures.SelectedIndex = i;
            heures.TopIndex = Math.Max(0, i - 3);
            return true;
        }
    }

    /// <summary>Carte blanche arrondie avec une fine bordure, qui sert de conteneur.</summary>
    public class CardPanel : Panel
    {
        public CardPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            BackColor = Theme.Surface;
            Padding = new Padding(20);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : Theme.Background);
            using (GraphicsPath forme = Formes.Arrondi(new Rectangle(0, 0, Width - 1, Height - 1), 10))
            {
                using (SolidBrush pinceau = new SolidBrush(BackColor))
                {
                    g.FillPath(pinceau, forme);
                }
                using (Pen stylo = new Pen(Theme.Border))
                {
                    g.DrawPath(stylo, forme);
                }
            }
        }
    }

    /// <summary>Tableau de données au style moderne, avec un message quand il est vide.</summary>
    public class FlatDataGridView : DataGridView
    {
        private string emptyText = "Aucun élément à afficher";

        public FlatDataGridView()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.None;
            BackgroundColor = Theme.Surface;
            GridColor = Theme.Border;
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            EnableHeadersVisualStyles = false;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 42;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.SurfaceHover,
                ForeColor = Theme.TextMuted,
                SelectionBackColor = Theme.SurfaceHover,
                SelectionForeColor = Theme.TextMuted,
                Font = Theme.Semibold(9.5F),
                Padding = new Padding(10, 0, 0, 0),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Theme.Surface,
                ForeColor = Theme.Text,
                SelectionBackColor = Theme.PrimarySoft,
                SelectionForeColor = Theme.Text,
                Font = Theme.Font(10F),
                Padding = new Padding(10, 0, 0, 0),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            RowTemplate.Height = 42;
            RowHeadersVisible = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            ReadOnly = true;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MultiSelect = false;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        [Category("Apparence"), DefaultValue("Aucun élément à afficher")]
        public string EmptyText { get { return emptyText; } set { emptyText = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Rows.Count == 0)
            {
                Rectangle zone = new Rectangle(0, ColumnHeadersVisible ? ColumnHeadersHeight : 0, Width,
                    Height - (ColumnHeadersVisible ? ColumnHeadersHeight : 0));
                TextRenderer.DrawText(e.Graphics, emptyText, Theme.Font(10F), zone, Theme.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);
            ClearSelection();
            Invalidate();
        }
    }

    /// <summary>Message temporaire (succès ou erreur) affiché dans la page au lieu d'une boîte de dialogue.</summary>
    public class StatusLabel : Label
    {
        private readonly Timer minuterie = new Timer();

        public StatusLabel()
        {
            AutoSize = false;
            Size = new Size(280, 40);
            Font = Theme.Font(9.5F);
            TextAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(10, 0, 6, 0);
            Visible = false;
            minuterie.Interval = 4000;
            minuterie.Tick += delegate { minuterie.Stop(); Visible = false; };
        }

        public void Succes(string message)
        {
            Afficher(message, Theme.Success, Theme.SuccessSoft);
        }

        public void Erreur(string message)
        {
            Afficher(message, Theme.Danger, Theme.DangerSoft);
        }

        private void Afficher(string message, Color texte, Color fond)
        {
            Text = message;
            ForeColor = texte;
            BackColor = fond;
            Visible = true;
            BringToFront();
            minuterie.Stop();
            minuterie.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                minuterie.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    /// <summary>Carte de statistique du tableau de bord : icône, titre et grande valeur.</summary>
    public class StatCard : Control
    {
        private string titre = "Titre";
        private string valeur = "0";
        private string iconGlyph = Glyphs.People;
        private Color accent = Theme.Primary;
        private Color accentSoft = Theme.PrimarySoft;

        public StatCard()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            Size = new Size(240, 112);
        }

        [Category("Apparence"), DefaultValue("Titre")]
        public string Titre { get { return titre; } set { titre = value; Invalidate(); } }

        [Category("Apparence"), DefaultValue("0")]
        public string Valeur { get { return valeur; } set { valeur = value; Invalidate(); } }

        [Category("Apparence")]
        public string IconGlyph { get { return iconGlyph; } set { iconGlyph = value ?? ""; Invalidate(); } }

        [Category("Apparence")]
        public Color Accent { get { return accent; } set { accent = value; Invalidate(); } }

        [Category("Apparence")]
        public Color AccentSoft { get { return accentSoft; } set { accentSoft = value; Invalidate(); } }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Parent != null ? Parent.BackColor : Theme.Background);

            using (GraphicsPath forme = Formes.Arrondi(new Rectangle(0, 0, Width - 1, Height - 1), 10))
            {
                using (SolidBrush fond = new SolidBrush(Theme.Surface))
                {
                    g.FillPath(fond, forme);
                }
                using (Pen stylo = new Pen(Theme.Border))
                {
                    g.DrawPath(stylo, forme);
                }
            }

            Rectangle pastille = new Rectangle(20, 20, 40, 40);
            using (GraphicsPath rond = Formes.Arrondi(pastille, 10))
            using (SolidBrush fond = new SolidBrush(accentSoft))
            {
                g.FillPath(fond, rond);
            }
            TextRenderer.DrawText(g, iconGlyph, Theme.Icon(14F), pastille, accent,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            TextRenderer.DrawText(g, titre, Theme.Font(9.5F), new Rectangle(72, 20, Width - 84, 20),
                Theme.TextMuted, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            // La valeur rétrécit (jusqu'à 12 pt) pour tenir entière dans la carte.
            Rectangle zoneValeur = new Rectangle(70, 40, Width - 82, 40);
            float taille = 20F;
            while (taille > 12F && TextRenderer.MeasureText(g, valeur, Theme.Semibold(taille), Size.Empty,
                       TextFormatFlags.SingleLine | TextFormatFlags.NoPadding).Width > zoneValeur.Width)
            {
                taille -= 1F;
            }
            TextRenderer.DrawText(g, valeur, Theme.Semibold(taille), zoneValeur,
                Theme.Text, TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis |
                TextFormatFlags.NoPadding | TextFormatFlags.SingleLine);
        }
    }

    /// <summary>Icône seule (police Segoe MDL2 Assets).</summary>
    public class IconLabel : Label
    {
        public IconLabel()
        {
            AutoSize = false;
            Font = Theme.Icon(16F);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.Transparent;
        }
    }

    internal static class Formes
    {
        public static GraphicsPath Arrondi(Rectangle r, int rayon)
        {
            GraphicsPath p = new GraphicsPath();
            if (rayon <= 0 || r.Width <= 0 || r.Height <= 0)
            {
                p.AddRectangle(r);
                return p;
            }
            int d = Math.Min(rayon * 2, Math.Min(r.Width, r.Height));
            p.AddArc(r.X, r.Y, d, d, 180, 90);
            p.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            p.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            p.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            p.CloseFigure();
            return p;
        }
    }
}
