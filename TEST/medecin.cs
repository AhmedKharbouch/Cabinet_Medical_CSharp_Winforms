using System;
using System.Windows.Forms;

namespace TEST
{
    /// <summary>Gestion des médecins : formulaire à gauche, liste avec recherche à droite.</summary>
    public partial class medecin : UserControl
    {
        /// <summary>Id du médecin en cours de modification, ou null en mode « ajout ».</summary>
        private int? idSelectionne;

        public medecin()
        {
            InitializeComponent();
        }

        private void medecin_Load(object sender, EventArgs e)
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
                    "SELECT id_MEDECIN AS Id, nom_med AS Nom, cin_med AS CIN, tel_med AS [Téléphone] " +
                    "FROM MEDECIN ORDER BY nom_med");
                grid.Columns["Id"].Visible = false;
            });
            AppliquerFiltre();
        }

        private void AppliquerFiltre()
        {
            Ui.Filtrer(grid.DataSource, txtRecherche.Text, "Nom", "CIN", "Téléphone");
            lblCompte.Text = Ui.Pluriel(grid.Rows.Count, "médecin", "médecins");
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
            lblForm.Text = "Nouveau médecin";
            lblFormSub.Text = "Remplissez les informations ci-dessous.";
            btnAjouter.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            grid.ClearSelection();
        }

        private void ModeEdition(DataGridViewRow ligne)
        {
            idSelectionne = Convert.ToInt32(ligne.Cells["Id"].Value);
            txtNom.Text = Convert.ToString(ligne.Cells["Nom"].Value);
            txtCin.Text = Convert.ToString(ligne.Cells["CIN"].Value);
            txtTel.Text = Convert.ToString(ligne.Cells["Téléphone"].Value);
            txtCin.Enabled = false;
            lblForm.Text = "Modifier le médecin";
            lblFormSub.Text = "La CIN ne peut pas être modifiée.";
            btnAjouter.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
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
                if (Db.Count("SELECT COUNT(*) FROM MEDECIN WHERE cin_med = @cin", Db.P("@cin", cin)) > 0)
                {
                    txtCin.Erreur = true;
                    lblStatut.Erreur("Un médecin avec cette CIN existe déjà.");
                    return;
                }

                Db.Execute("INSERT INTO MEDECIN (cin_med, nom_med, tel_med) VALUES (@cin, @nom, @tel)",
                    Db.P("@cin", cin), Db.P("@nom", nom), Db.P("@tel", tel));
                lblStatut.Succes("Médecin « " + nom + " » ajouté.");
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
                Db.Execute("UPDATE MEDECIN SET nom_med = @nom, tel_med = @tel WHERE id_MEDECIN = @id",
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
            if (!Db.Confirmer("Supprimer le médecin « " + nom + " » et toutes ses consultations ?\n\nCette action est définitive."))
            {
                return;
            }

            int id = idSelectionne.Value;
            Db.TryRun(delegate
            {
                Db.Execute(
                    "SET XACT_ABORT ON; BEGIN TRAN; " +
                    "DELETE FROM CONSULTATION WHERE id_MEDECIN = @id; " +
                    "DELETE FROM MEDECIN WHERE id_MEDECIN = @id; " +
                    "COMMIT;",
                    Db.P("@id", id));
                lblStatut.Succes("Médecin « " + nom + " » supprimé.");
                ModeAjout();
                refr();
            });
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            ModeAjout();
            txtNom.Focus();
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
