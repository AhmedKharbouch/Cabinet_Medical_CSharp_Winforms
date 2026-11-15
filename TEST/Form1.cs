using System;
using System.Windows.Forms;
using TEST.Controls;

namespace TEST
{
    /// <summary>Fenêtre principale : menu latéral et une page affichée à la fois.</summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>Vrai si la fenêtre a été fermée par « Se déconnecter » (retour à l'écran de connexion).</summary>
        public bool Deconnexion { get; private set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblUtilisateur.Text = "Dr " + (Session.NomMedecin ?? "");
            accueil1.ConsultationDemandee += delegate(object s, CalendrierEventArgs ev)
            {
                consultation1.refr();
                Afficher(consultation1, btnConsultations);
                consultation1.OuvrirConsultation(ev.Id.Value);
            };
            patient1.ConsultationDemandee += delegate(object s, CalendrierEventArgs ev)
            {
                consultation1.refr();
                Afficher(consultation1, btnConsultations);
                consultation1.OuvrirConsultation(ev.Id.Value);
            };
            patient1.NouvelleConsultationDemandee += delegate(object s, CalendrierEventArgs ev)
            {
                consultation1.refr();
                Afficher(consultation1, btnConsultations);
                consultation1.PreparerNouvellePourPatient(ev.Id.Value);
            };
            accueil1.NouvelleConsultationDemandee += delegate(object s, CalendrierEventArgs ev)
            {
                consultation1.refr();
                Afficher(consultation1, btnConsultations);
                consultation1.PreparerNouvelle(ev.Date);
            };
            Afficher(accueil1, btnAccueil);
        }

        /// <summary>Affiche une page, masque les autres et met le bouton du menu en surbrillance.</summary>
        private void Afficher(UserControl page, FlatButton bouton)
        {
            UserControl[] pages = { accueil1, patient1, medecin1, medicament1, consultation1 };
            foreach (UserControl p in pages)
            {
                p.Visible = p == page;
            }

            FlatButton[] boutons = { btnAccueil, btnPatients, btnMedecins, btnMedicaments, btnConsultations };
            foreach (FlatButton b in boutons)
            {
                b.Selected = b == bouton;
            }

            page.BringToFront();
            Text = "Cabinet Médical — " + bouton.Text;
        }

        private void btnAccueil_Click(object sender, EventArgs e)
        {
            accueil1.refr();
            Afficher(accueil1, btnAccueil);
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            patient1.refr();
            Afficher(patient1, btnPatients);
        }

        private void btnMedecins_Click(object sender, EventArgs e)
        {
            medecin1.refr();
            Afficher(medecin1, btnMedecins);
        }

        private void btnMedicaments_Click(object sender, EventArgs e)
        {
            medicament1.refr();
            Afficher(medicament1, btnMedicaments);
        }

        private void btnConsultations_Click(object sender, EventArgs e)
        {
            consultation1.refr();
            Afficher(consultation1, btnConsultations);
        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            if (Db.Confirmer("Voulez-vous vous déconnecter ?"))
            {
                Deconnexion = true;
                Close();
            }
        }
    }
}
