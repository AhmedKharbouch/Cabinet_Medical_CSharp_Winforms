using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using TEST.Controls;

namespace TEST
{
    /// <summary>
    /// Gestion des consultations : formulaire à gauche, calendrier mensuel (ou liste) à droite.
    /// Le patient et le médecin se choisissent dans des listes par leur nom.
    /// </summary>
    public partial class consultation : UserControl
    {
        /// <summary>Id de la consultation en cours de modification, ou null en mode « ajout ».</summary>
        private int? idSelectionne;

        /// <summary>Vue affichée à droite : calendrier (par défaut) ou liste.</summary>
        private bool vueCalendrier = true;

        public consultation()
        {
            InitializeComponent();
        }

        private void consultation_Load(object sender, EventArgs e)
        {
            if (!Db.EnModeConception)
            {
                AfficherVue(true);
                refr();
                ModeAjout();
            }
        }

        /// <summary>Recharge les listes de patients et de médecins, puis les consultations.</summary>
        public void refr()
        {
            object patient = cboPatient.SelectedValue;
            object medecin = cboMedecin.SelectedValue;

            Db.TryRun(delegate
            {
                cboPatient.DisplayMember = "nom";
                cboPatient.ValueMember = "id";
                cboPatient.DataSource = Db.Query("SELECT id_PATIENT AS id, nom_pat AS nom FROM PATIENT ORDER BY nom_pat");

                cboMedecin.DisplayMember = "nom";
                cboMedecin.ValueMember = "id";
                cboMedecin.DataSource = Db.Query("SELECT id_MEDECIN AS id, nom_med AS nom FROM MEDECIN ORDER BY nom_med");

                ChargerConsultations();
            });

            cboPatient.SelectedValue = patient;
            cboMedecin.SelectedValue = medecin;
        }

        private DataTable Consultations
        {
            get { return grid.DataSource as DataTable; }
        }

        private void ChargerConsultations()
        {
            grid.DataSource = Db.Query(
                "SELECT c.id_CONSULTATION AS Id, c.date_cons AS [Date], p.nom_pat AS Patient, " +
                "       m.nom_med AS [Médecin], c.prix_cons AS Prix, c.id_PATIENT, c.id_MEDECIN " +
                "FROM CONSULTATION c " +
                "JOIN PATIENT p ON p.id_PATIENT = c.id_PATIENT " +
                "JOIN MEDECIN m ON m.id_MEDECIN = c.id_MEDECIN " +
                "ORDER BY c.date_cons DESC");
            grid.Columns["Id"].Visible = false;
            grid.Columns["id_PATIENT"].Visible = false;
            grid.Columns["id_MEDECIN"].Visible = false;
            grid.Columns["Date"].DefaultCellStyle.Format = "ddd d MMM yyyy  ·  HH:mm";
            grid.Columns["Prix"].DefaultCellStyle.Format = "N2";
            grid.Columns["Date"].FillWeight = 190;
            grid.Columns["Prix"].FillWeight = 70;
            AppliquerFiltre();
        }

        /// <summary>Applique la recherche à la liste et au calendrier, et met à jour le compteur.</summary>
        private void AppliquerFiltre()
        {
            Ui.Filtrer(grid.DataSource, txtRecherche.Text, "Patient", "Médecin");
            grid.ClearSelection();

            List<CalendrierEvenement> evenements = new List<CalendrierEvenement>();
            DataTable table = Consultations;
            if (table != null)
            {
                foreach (DataRowView v in table.DefaultView)
                {
                    evenements.Add(new CalendrierEvenement
                    {
                        Id = Convert.ToInt32(v["Id"]),
                        Debut = Convert.ToDateTime(v["Date"]),
                        Titre = Convert.ToString(v["Patient"]),
                        Detail = "Dr " + v["Médecin"] + "  ·  " + Convert.ToDecimal(v["Prix"]).ToString("N2"),
                        Groupe = Convert.ToInt32(v["id_MEDECIN"])
                    });
                }
            }
            calendrier.DefinirEvenements(evenements);
            MettreAJourCompteur();
        }

        private void MettreAJourCompteur()
        {
            if (vueCalendrier)
            {
                lblCompte.Text = Ui.Pluriel(calendrier.NombreDansLeMois(), "consultation", "consultations") + " ce mois-ci";
            }
            else
            {
                lblCompte.Text = Ui.Pluriel(grid.Rows.Count, "consultation", "consultations");
            }
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void txtPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            Db.ChiffresSeulement(e);
        }

        // --- Vues calendrier / liste ---

        private void AfficherVue(bool calendrierVisible)
        {
            vueCalendrier = calendrierVisible;
            calendrier.Visible = calendrierVisible;
            grid.Visible = !calendrierVisible;
            btnVueCalendrier.Variant = calendrierVisible ? ButtonVariant.Primary : ButtonVariant.Secondary;
            btnVueListe.Variant = calendrierVisible ? ButtonVariant.Secondary : ButtonVariant.Primary;
            lblListe.Text = calendrierVisible ? "Calendrier des consultations" : "Liste des consultations";
            MettreAJourCompteur();
        }

        private void btnVueCalendrier_Click(object sender, EventArgs e)
        {
            AfficherVue(true);
        }

        private void btnVueListe_Click(object sender, EventArgs e)
        {
            AfficherVue(false);
        }

        private void calendrier_EvenementClique(object sender, CalendrierEventArgs e)
        {
            DataTable table = Consultations;
            if (table == null || !e.Id.HasValue)
            {
                return;
            }
            foreach (DataRow r in table.Rows)
            {
                if (Convert.ToInt32(r["Id"]) == e.Id.Value)
                {
                    ModeEdition(r);
                    return;
                }
            }
        }

        /// <summary>Clic sur un jour : prépare une nouvelle consultation à cette date.</summary>
        private void calendrier_JourClique(object sender, CalendrierEventArgs e)
        {
            if (e.Date < DateTime.Today)
            {
                lblStatut.Erreur("Impossible de planifier une consultation dans le passé.");
                return;
            }

            TimeSpan heure = dtpDate.Value.TimeOfDay;
            if (idSelectionne != null)
            {
                ModeAjout();
                heure = dtpDate.Value.TimeOfDay;
            }
            dtpDate.Value = e.Date.Date + heure;
            lblFormSub.Text = "Nouvelle consultation le " + e.Date.ToString("dddd d MMMM") + ".";
            cboPatient.Focus();
        }

        /// <summary>Ouvre une consultation existante (appelé depuis le tableau de bord).</summary>
        public void OuvrirConsultation(int id)
        {
            AfficherVue(true);
            calendrier_EvenementClique(this, new CalendrierEventArgs(id, DateTime.Today));
            if (idSelectionne.HasValue)
            {
                calendrier.Mois = dtpDate.Value;
            }
        }

        /// <summary>Prépare une nouvelle consultation à une date (appelé depuis le tableau de bord).</summary>
        public void PreparerNouvelle(DateTime jour)
        {
            AfficherVue(true);
            ModeAjout();
            calendrier.Mois = jour;
            calendrier_JourClique(this, new CalendrierEventArgs(null, jour));
        }

        /// <summary>Prépare une nouvelle consultation pour un patient (appelé depuis son historique).</summary>
        public void PreparerNouvellePourPatient(int idPatient)
        {
            ModeAjout();
            cboPatient.SelectedValue = idPatient;
            lblFormSub.Text = "Choisissez le médecin et l'horaire.";
            cboMedecin.Focus();
        }

        private void calendrier_MoisChange(object sender, EventArgs e)
        {
            MettreAJourCompteur();
        }

        // --- Modes du formulaire ---

        private void ModeAjout()
        {
            idSelectionne = null;
            calendrier.Selection = null;
            cboPatient.SelectedIndex = -1;
            cboMedecin.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today.AddHours(DateTime.Now.Hour + 1);
            txtPrix.Clear();
            lblForm.Text = "Nouvelle consultation";
            lblFormSub.Text = "Choisissez le patient, le médecin et l'horaire.";
            btnAjouter.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            grid.ClearSelection();
        }

        private void ModeEdition(DataRow ligne)
        {
            idSelectionne = Convert.ToInt32(ligne["Id"]);
            calendrier.Selection = idSelectionne;
            cboPatient.SelectedValue = ligne["id_PATIENT"];
            cboMedecin.SelectedValue = ligne["id_MEDECIN"];
            if (ligne["Date"] != DBNull.Value)
            {
                dtpDate.Value = Convert.ToDateTime(ligne["Date"]);
            }
            txtPrix.Text = Convert.ToDecimal(ligne["Prix"]).ToString("0.##");
            lblForm.Text = "Modifier la consultation";
            lblFormSub.Text = "Modifiez les informations puis enregistrez.";
            btnAjouter.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
        }

        /// <summary>Vérifie la saisie ; renvoie false (avec un message) si elle est incomplète.</summary>
        private bool LireSaisie(out int idPatient, out int idMedecin, out decimal prix)
        {
            idPatient = 0;
            idMedecin = 0;
            prix = 0;

            if (cboPatient.SelectedValue == null)
            {
                lblStatut.Erreur("Choisissez un patient.");
                return false;
            }
            if (cboMedecin.SelectedValue == null)
            {
                lblStatut.Erreur("Choisissez un médecin.");
                return false;
            }
            if (!decimal.TryParse(txtPrix.Text.Trim(), out prix))
            {
                txtPrix.Erreur = true;
                lblStatut.Erreur("Saisissez un prix valide.");
                return false;
            }

            idPatient = Convert.ToInt32(cboPatient.SelectedValue);
            idMedecin = Convert.ToInt32(cboMedecin.SelectedValue);
            return true;
        }

        // --- Actions ---

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            int idPatient, idMedecin;
            decimal prix;
            if (!LireSaisie(out idPatient, out idMedecin, out prix))
            {
                return;
            }
            if (dtpDate.Value.Date < DateTime.Today)
            {
                lblStatut.Erreur("La date ne peut pas être dans le passé.");
                return;
            }

            DateTime date = dtpDate.Value;
            Db.TryRun(delegate
            {
                Db.Execute(
                    "INSERT INTO CONSULTATION (prix_cons, date_cons, id_PATIENT, id_MEDECIN) " +
                    "VALUES (@prix, @date, @patient, @medecin)",
                    Db.P("@prix", prix), Db.P("@date", date),
                    Db.P("@patient", idPatient), Db.P("@medecin", idMedecin));
                lblStatut.Succes("Consultation ajoutée pour le " + date.ToString("dd/MM/yyyy à HH:mm") + ".");
                ModeAjout();
                ChargerConsultations();
                calendrier.Mois = date;
            });
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int idPatient, idMedecin;
            decimal prix;
            if (idSelectionne == null || !LireSaisie(out idPatient, out idMedecin, out prix))
            {
                return;
            }

            int id = idSelectionne.Value;
            DateTime date = dtpDate.Value;
            Db.TryRun(delegate
            {
                Db.Execute(
                    "UPDATE CONSULTATION SET prix_cons = @prix, date_cons = @date, " +
                    "id_PATIENT = @patient, id_MEDECIN = @medecin WHERE id_CONSULTATION = @id",
                    Db.P("@prix", prix), Db.P("@date", date),
                    Db.P("@patient", idPatient), Db.P("@medecin", idMedecin), Db.P("@id", id));
                lblStatut.Succes("Modifications enregistrées.");
                ModeAjout();
                ChargerConsultations();
                calendrier.Mois = date;
            });
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (idSelectionne == null)
            {
                return;
            }
            if (!Db.Confirmer("Supprimer cette consultation ?"))
            {
                return;
            }

            int id = idSelectionne.Value;
            Db.TryRun(delegate
            {
                Db.Execute("DELETE FROM CONSULTATION WHERE id_CONSULTATION = @id", Db.P("@id", id));
                lblStatut.Succes("Consultation supprimée.");
                ModeAjout();
                ChargerConsultations();
            });
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ModeAjout();
            cboPatient.Focus();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataRowView vue = grid.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (vue != null)
            {
                ModeEdition(vue.Row);
            }
        }
    }
}
