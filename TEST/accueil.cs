using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TEST.Controls;

namespace TEST
{
    /// <summary>Tableau de bord : chiffres clés et prochaines consultations (en liste ou en calendrier).</summary>
    public partial class accueil : UserControl
    {
        /// <summary>Demande d'ouverture d'une consultation (clic dans la liste ou le calendrier).</summary>
        public event EventHandler<CalendrierEventArgs> ConsultationDemandee;

        /// <summary>Demande de nouvelle consultation à une date (clic sur un jour du calendrier).</summary>
        public event EventHandler<CalendrierEventArgs> NouvelleConsultationDemandee;

        public accueil()
        {
            InitializeComponent();
        }

        private void accueil_Load(object sender, EventArgs e)
        {
            if (!Db.EnModeConception)
            {
                AfficherVue(Session.DashboardEnCalendrier);
                refr();
            }
        }

        public void refr()
        {
            string date = DateTime.Now.ToString("dddd d MMMM yyyy");
            lblSousTitre.Text = "Bonjour Dr " + (Session.NomMedecin ?? "") + "  ·  " +
                                char.ToUpper(date[0]) + date.Substring(1);

            Db.TryRun(delegate
            {
                DataTable stats = Db.Query(
                    "SELECT " +
                    " (SELECT COUNT(*) FROM PATIENT) AS patients," +
                    " (SELECT COUNT(*) FROM MEDECIN) AS medecins," +
                    " (SELECT COUNT(*) FROM CONSULTATION WHERE CAST(date_cons AS date) = CAST(GETDATE() AS date)) AS aujourdhui," +
                    " (SELECT ISNULL(SUM(prix_cons), 0) FROM CONSULTATION" +
                    "    WHERE YEAR(date_cons) = YEAR(GETDATE()) AND MONTH(date_cons) = MONTH(GETDATE())) AS recettes");
                DataRow r = stats.Rows[0];
                statPatients.Valeur = Convert.ToInt32(r["patients"]).ToString();
                statMedecins.Valeur = Convert.ToInt32(r["medecins"]).ToString();
                statAujourdhui.Valeur = Convert.ToInt32(r["aujourdhui"]).ToString();
                statRecettes.Valeur = Convert.ToDecimal(r["recettes"]).ToString("N2");

                // Liste : les 20 prochaines consultations
                gridProchaines.DataSource = Db.Query(
                    "SELECT TOP 20 c.id_CONSULTATION AS Id, c.date_cons AS [Date], p.nom_pat AS Patient, " +
                    "       m.nom_med AS [Médecin], c.prix_cons AS Prix " +
                    "FROM CONSULTATION c " +
                    "JOIN PATIENT p ON p.id_PATIENT = c.id_PATIENT " +
                    "JOIN MEDECIN m ON m.id_MEDECIN = c.id_MEDECIN " +
                    "WHERE c.date_cons >= CAST(GETDATE() AS date) " +
                    "ORDER BY c.date_cons");
                gridProchaines.Columns["Id"].Visible = false;
                gridProchaines.Columns["Date"].DefaultCellStyle.Format = "ddd d MMM yyyy  ·  HH:mm";
                gridProchaines.Columns["Prix"].DefaultCellStyle.Format = "N2";
                gridProchaines.Columns["Date"].FillWeight = 150;
                gridProchaines.Columns["Prix"].FillWeight = 70;

                // Calendrier : toutes les consultations (on navigue de mois en mois)
                DataTable toutes = Db.Query(
                    "SELECT c.id_CONSULTATION, c.date_cons, p.nom_pat, m.nom_med, c.prix_cons, c.id_MEDECIN " +
                    "FROM CONSULTATION c " +
                    "JOIN PATIENT p ON p.id_PATIENT = c.id_PATIENT " +
                    "JOIN MEDECIN m ON m.id_MEDECIN = c.id_MEDECIN");
                List<CalendrierEvenement> evenements = new List<CalendrierEvenement>();
                foreach (DataRow c in toutes.Rows)
                {
                    evenements.Add(new CalendrierEvenement
                    {
                        Id = Convert.ToInt32(c["id_CONSULTATION"]),
                        Debut = Convert.ToDateTime(c["date_cons"]),
                        Titre = Convert.ToString(c["nom_pat"]),
                        Detail = "Dr " + c["nom_med"] + "  ·  " + Convert.ToDecimal(c["prix_cons"]).ToString("N2"),
                        Groupe = Convert.ToInt32(c["id_MEDECIN"])
                    });
                }
                calendrierProchaines.DefinirEvenements(evenements);
            });
        }

        // --- Choix de la vue ---

        private void AfficherVue(bool calendrier)
        {
            Session.DashboardEnCalendrier = calendrier;
            calendrierProchaines.Visible = calendrier;
            gridProchaines.Visible = !calendrier;
            btnVueCalendrier.Variant = calendrier ? ButtonVariant.Primary : ButtonVariant.Secondary;
            btnVueListe.Variant = calendrier ? ButtonVariant.Secondary : ButtonVariant.Primary;
            lblProchaines.Text = calendrier ? "Calendrier des consultations" : "Prochaines consultations";
            lblProchainesSub.Text = calendrier
                ? "Cliquez sur une consultation pour l'ouvrir, ou sur un jour pour en planifier une."
                : "Les 20 prochains rendez-vous, à partir d'aujourd'hui. Cliquez sur une ligne pour l'ouvrir.";
        }

        private void btnVueCalendrier_Click(object sender, EventArgs e)
        {
            AfficherVue(true);
        }

        private void btnVueListe_Click(object sender, EventArgs e)
        {
            AfficherVue(false);
        }

        // --- Ouverture dans la page Consultations ---

        private void gridProchaines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewRow ligne = gridProchaines.Rows[e.RowIndex];
            Demander(ConsultationDemandee, new CalendrierEventArgs(
                Convert.ToInt32(ligne.Cells["Id"].Value), Convert.ToDateTime(ligne.Cells["Date"].Value)));
        }

        private void calendrierProchaines_EvenementClique(object sender, CalendrierEventArgs e)
        {
            Demander(ConsultationDemandee, e);
        }

        private void calendrierProchaines_JourClique(object sender, CalendrierEventArgs e)
        {
            if (e.Date < DateTime.Today)
            {
                return;
            }
            Demander(NouvelleConsultationDemandee, e);
        }

        private void Demander(EventHandler<CalendrierEventArgs> evenement, CalendrierEventArgs e)
        {
            if (evenement != null)
            {
                evenement(this, e);
            }
        }
    }
}
