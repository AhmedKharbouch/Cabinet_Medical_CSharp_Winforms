using System;
using System.Windows.Forms;

namespace TEST
{
    /// <summary>Écran de connexion : un médecin se connecte avec son nom et sa CIN.</summary>
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            lblErreur.Text = "";
            string nom = txtNom.Text.Trim();
            string cin = txtCin.Text.Trim();

            txtNom.Erreur = nom.Length == 0;
            txtCin.Erreur = cin.Length == 0;
            if (nom.Length == 0 || cin.Length == 0)
            {
                lblErreur.Text = "Veuillez saisir votre nom et votre CIN.";
                return;
            }

            string nomTrouve = null;
            btnConnexion.Enabled = false;
            Cursor = Cursors.WaitCursor;
            bool ok = Db.TryRun(delegate
            {
                object resultat = Db.Scalar(
                    "SELECT nom_med FROM MEDECIN WHERE cin_med = @cin AND nom_med = @nom",
                    Db.P("@cin", cin), Db.P("@nom", nom));
                nomTrouve = resultat as string;
            });
            Cursor = Cursors.Default;
            btnConnexion.Enabled = true;

            if (!ok)
            {
                return;
            }
            if (nomTrouve == null)
            {
                txtCin.Clear();
                txtCin.Erreur = true;
                txtCin.Focus();
                lblErreur.Text = "Nom ou CIN incorrect.";
                return;
            }

            Session.NomMedecin = nomTrouve;
            Form1 principal = new Form1();
            principal.FormClosed += Principal_FormClosed;
            principal.Show();
            Hide();
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 principal = (Form1)sender;
            if (principal.Deconnexion)
            {
                Session.NomMedecin = null;
                txtNom.Clear();
                txtCin.Clear();
                lblErreur.Text = "";
                Show();
                txtNom.Focus();
            }
            else
            {
                Close();
            }
        }
    }
}
