using System;
using System.Windows.Forms;

namespace TEST
{
    /// <summary>Gestion des médicaments : formulaire à gauche, liste avec recherche à droite.</summary>
    public partial class medicament : UserControl
    {
        /// <summary>Nom du médicament en cours de modification, ou null en mode « ajout ».</summary>
        private string nomSelectionne;

        public medicament()
        {
            InitializeComponent();
        }

        private void medicament_Load(object sender, EventArgs e)
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
                grid.DataSource = Db.Query("SELECT nom_medoc AS Nom FROM MEDICAMENT ORDER BY nom_medoc");
            });
            AppliquerFiltre();
        }

        private void AppliquerFiltre()
        {
            Ui.Filtrer(grid.DataSource, txtRecherche.Text, "Nom");
            lblCompte.Text = Ui.Pluriel(grid.Rows.Count, "médicament", "médicaments");
            grid.ClearSelection();
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void ModeAjout()
        {
            nomSelectionne = null;
            txtNom.Clear();
            lblForm.Text = "Nouveau médicament";
            lblFormSub.Text = "Saisissez le nom du médicament.";
            btnAjouter.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
            grid.ClearSelection();
        }

        private void ModeEdition(DataGridViewRow ligne)
        {
            nomSelectionne = Convert.ToString(ligne.Cells["Nom"].Value);
            txtNom.Text = nomSelectionne;
            lblForm.Text = "Modifier le médicament";
            lblFormSub.Text = "Modifiez le nom puis enregistrez.";
            btnAjouter.Visible = false;
            btnModifier.Visible = true;
            btnSupprimer.Visible = true;
        }

        private bool Valider()
        {
            txtNom.Erreur = txtNom.Text.Trim().Length == 0;
            if (txtNom.Erreur)
            {
                lblStatut.Erreur("Veuillez saisir le nom du médicament.");
                return false;
            }
            return true;
        }

        private bool Existe(string nom)
        {
            return Db.Count("SELECT COUNT(*) FROM MEDICAMENT WHERE nom_medoc = @nom", Db.P("@nom", nom)) > 0;
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (!Valider())
            {
                return;
            }

            string nom = txtNom.Text.Trim();
            Db.TryRun(delegate
            {
                if (Existe(nom))
                {
                    txtNom.Erreur = true;
                    lblStatut.Erreur("Ce médicament existe déjà.");
                    return;
                }

                Db.Execute("INSERT INTO MEDICAMENT (nom_medoc) VALUES (@nom)", Db.P("@nom", nom));
                lblStatut.Succes("Médicament « " + nom + " » ajouté.");
                ModeAjout();
                refr();
            });
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (nomSelectionne == null || !Valider())
            {
                return;
            }

            string ancien = nomSelectionne;
            string nouveau = txtNom.Text.Trim();
            Db.TryRun(delegate
            {
                if (nouveau != ancien && Existe(nouveau))
                {
                    txtNom.Erreur = true;
                    lblStatut.Erreur("Ce médicament existe déjà.");
                    return;
                }

                Db.Execute("UPDATE MEDICAMENT SET nom_medoc = @nouveau WHERE nom_medoc = @ancien",
                    Db.P("@nouveau", nouveau), Db.P("@ancien", ancien));
                lblStatut.Succes("Modifications enregistrées.");
                ModeAjout();
                refr();
            });
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (nomSelectionne == null)
            {
                return;
            }
            string nom = nomSelectionne;
            if (!Db.Confirmer("Supprimer le médicament « " + nom + " » ?"))
            {
                return;
            }

            Db.TryRun(delegate
            {
                Db.Execute("DELETE FROM MEDICAMENT WHERE nom_medoc = @nom", Db.P("@nom", nom));
                lblStatut.Succes("Médicament « " + nom + " » supprimé.");
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
