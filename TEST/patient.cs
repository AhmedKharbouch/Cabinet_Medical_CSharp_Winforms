using System;
using System.Windows.Forms;
using TEST.Controls;

namespace TEST
{
    /// <summary>Gestion des patients : formulaire à gauche, liste avec recherche à droite.</summary>
    public partial class patient : UserControl
    {
        /// <summary>Id du patient en cours de modification, ou null en mode « ajout ».</summary>
        private int? idSelectionne;

        public patient()
        {
            InitializeComponent();
        }

        private void patient_Load(object sender, EventArgs e)
        {
            if (!Db.EnModeConception)
            {
                ModeAjout();
                refr();
            }
        }

        public void refr()
        {
            Db.TryRun(delegate
            {
                grid.DataSource = Db.Query(
                    "SELECT p.id_PATIENT AS Id, p.nom_pat AS Nom, p.cin_pat AS CIN, p.tel_pat AS [Téléphone], " +
                    "  (SELECT COUNT(*) FROM CONSULTATION c WHERE c.id_PATIENT = p.id_PATIENT) AS Consultations, " +
                    "  (SELECT MAX(c.date_cons) FROM CONSULTATION c " +
                    "     WHERE c.id_PATIENT = p.id_PATIENT AND c.date_cons <= GETDATE()) AS [Dernière visite] " +
                    "FROM PATIENT p ORDER BY p.nom_pat");
                grid.Columns["Id"].Visible = false;
                grid.Columns["Dernière visite"].DefaultCellStyle.Format = "dd/MM/yyyy";
                grid.Columns["Dernière visite"].DefaultCellStyle.NullValue = "—";
                grid.Columns["Consultations"].FillWeight = 115;
            });
            AppliquerFiltre();
        }

        private void AppliquerFiltre()
        {
            Ui.Filtrer(grid.DataSource, txtRecherche.Text, "Nom", "CIN", "Téléphone");
            lblCompte.Text = Ui.Pluriel(grid.Rows.Count, "patient", "patients");
            grid.ClearSelection();
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            Db.ChiffresSeulement(e);
        }

        // --- Modes du formulaire ---

        private void ModeAjout()
        {
            idSelectionne = null;
            txtNom.Clear();
            txtCin.Clear();
            txtTel.Clear();
            txtCin.Enabled = true;
            lblForm.Text = "Nouveau patient";
            lblFormSub.Text = "Remplissez les informations ci-dessous.";
            btnAjouter.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            btnHistorique.Visible = false;
            grid.ClearSelection();
        }

        private void ModeEdition(DataGridViewRow ligne)
        {
            idSelectionne = Convert.ToInt32(ligne.Cells["Id"].Value);
            txtNom.Text = Convert.ToString(ligne.Cells["Nom"].Value);
            txtCin.Text = Convert.ToString(ligne.Cells["CIN"].Value);
            txtTel.Text = Convert.ToString(ligne.Cells["Téléphone"].Value);
            txtCin.Enabled = false;
            lblForm.Text = "Modifier le patient";
            lblFormSub.Text = "La CIN ne peut pas être modifiée.";
            btnAjouter.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
            btnHistorique.Visible = true;
        }

        private bool Valider()
        {
            txtNom.Erreur = txtNom.Text.Trim().Length == 0;
            txtCin.Erreur = txtCin.Text.Trim().Length == 0;
            txtTel.Erreur = txtTel.Text.Trim().Length == 0;
            if (txtNom.Erreur || txtCin.Erreur || txtTel.Erreur)
            {
                lblStatut.Erreur("Veuillez remplir les champs en rouge.");
                return false;
            }
            return true;
        }

        // --- Actions ---

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!Valider())
            {
                return;
            }

            string nom = txtNom.Text.Trim();
            string cin = txtCin.Text.Trim();
            string tel = txtTel.Text.Trim();

            Db.TryRun(delegate
            {
                if (Db.Count("SELECT COUNT(*) FROM PATIENT WHERE cin_pat = @cin", Db.P("@cin", cin)) > 0)
                {
                    txtCin.Erreur = true;
                    lblStatut.Erreur("Un patient avec cette CIN existe déjà.");
                    return;
                }

                Db.Execute("INSERT INTO PATIENT (cin_pat, nom_pat, tel_pat) VALUES (@cin, @nom, @tel)",
                    Db.P("@cin", cin), Db.P("@nom", nom), Db.P("@tel", tel));
                lblStatut.Succes("Patient « " + nom + " » ajouté.");
                ModeAjout();
                refr();
            });
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (idSelectionne == null || !Valider())
            {
                return;
            }

            string nom = txtNom.Text.Trim();
            string tel = txtTel.Text.Trim();
            int id = idSelectionne.Value;

            Db.TryRun(delegate
            {
                Db.Execute("UPDATE PATIENT SET nom_pat = @nom, tel_pat = @tel WHERE id_PATIENT = @id",
                    Db.P("@nom", nom), Db.P("@tel", tel), Db.P("@id", id));
                lblStatut.Succes("Modifications enregistrées.");
                ModeAjout();
                refr();
            });
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (idSelectionne == null)
            {
                return;
            }

            string nom = txtNom.Text.Trim();
            if (!Db.Confirmer("Supprimer le patient « " + nom + " » et toutes ses consultations ?\n\nCette action est définitive."))
            {
                return;
            }

            int id = idSelectionne.Value;
            Db.TryRun(delegate
            {
                Db.Execute(
                    "SET XACT_ABORT ON; BEGIN TRAN; " +
                    "DELETE FROM CONSULTATION WHERE id_PATIENT = @id; " +
                    "DELETE FROM PATIENT WHERE id_PATIENT = @id; " +
                    "COMMIT;",
                    Db.P("@id", id));
                lblStatut.Succes("Patient « " + nom + " » supprimé.");
                ModeAjout();
                refr();
            });
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ModeAjout();
            txtNom.Focus();
        }

        // --- Historique ---

        /// <summary>Demande d'ouverture d'une consultation depuis l'historique.</summary>
        public event EventHandler<CalendrierEventArgs> ConsultationDemandee;

        /// <summary>Demande de nouvelle consultation pour un patient (Id = id du patient).</summary>
        public event EventHandler<CalendrierEventArgs> NouvelleConsultationDemandee;

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            OuvrirHistorique();
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ModeEdition(grid.Rows[e.RowIndex]);
                OuvrirHistorique();
            }
        }

        private void OuvrirHistorique()
        {
            if (idSelectionne == null)
            {
                return;
            }

            int id = idSelectionne.Value;
            using (HistoriquePatient fenetre = new HistoriquePatient(id, txtNom.Text.Trim(), txtCin.Text.Trim(), txtTel.Text.Trim()))
            {
                if (fenetre.ShowDialog(FindForm()) != DialogResult.OK)
                {
                    return;
                }

                EventHandler<CalendrierEventArgs> h;
                if (fenetre.ConsultationChoisie.HasValue)
                {
                    h = ConsultationDemandee;
                    if (h != null) h(this, new CalendrierEventArgs(fenetre.ConsultationChoisie.Value, DateTime.Today));
                }
                else if (fenetre.NouvelleDemandee)
                {
                    h = NouvelleConsultationDemandee;
                    if (h != null) h(this, new CalendrierEventArgs(id, DateTime.Today));
                }
            }
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ModeEdition(grid.Rows[e.RowIndex]);
            }
        }
    }
}
