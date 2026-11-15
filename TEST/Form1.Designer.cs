namespace TEST
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnDeconnexion = new TEST.Controls.FlatButton();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblUtilisateur = new System.Windows.Forms.Label();
            this.btnConsultations = new TEST.Controls.FlatButton();
            this.btnMedicaments = new TEST.Controls.FlatButton();
            this.btnMedecins = new TEST.Controls.FlatButton();
            this.btnPatients = new TEST.Controls.FlatButton();
            this.btnAccueil = new TEST.Controls.FlatButton();
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblAppSub = new System.Windows.Forms.Label();
            this.lblApp = new System.Windows.Forms.Label();
            this.iconLogo = new TEST.Controls.IconLabel();
            this.panelContenu = new System.Windows.Forms.Panel();
            this.accueil1 = new TEST.accueil();
            this.patient1 = new TEST.patient();
            this.medecin1 = new TEST.medecin();
            this.medicament1 = new TEST.medicament();
            this.consultation1 = new TEST.consultation();
            this.panelSidebar.SuspendLayout();
            this.panelContenu.SuspendLayout();
            this.SuspendLayout();
            //
            // panelSidebar
            //
            this.panelSidebar.BackColor = TEST.Controls.Theme.Sidebar;
            this.panelSidebar.Controls.Add(this.btnDeconnexion);
            this.panelSidebar.Controls.Add(this.lblRole);
            this.panelSidebar.Controls.Add(this.lblUtilisateur);
            this.panelSidebar.Controls.Add(this.btnConsultations);
            this.panelSidebar.Controls.Add(this.btnMedicaments);
            this.panelSidebar.Controls.Add(this.btnMedecins);
            this.panelSidebar.Controls.Add(this.btnPatients);
            this.panelSidebar.Controls.Add(this.btnAccueil);
            this.panelSidebar.Controls.Add(this.lblMenu);
            this.panelSidebar.Controls.Add(this.lblAppSub);
            this.panelSidebar.Controls.Add(this.lblApp);
            this.panelSidebar.Controls.Add(this.iconLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(240, 780);
            this.panelSidebar.TabIndex = 0;
            //
            // iconLogo
            //
            this.iconLogo.BackColor = TEST.Controls.Theme.Primary;
            this.iconLogo.Font = new System.Drawing.Font("Segoe MDL2 Assets", 15F);
            this.iconLogo.ForeColor = System.Drawing.Color.White;
            this.iconLogo.Location = new System.Drawing.Point(20, 24);
            this.iconLogo.Name = "iconLogo";
            this.iconLogo.Size = new System.Drawing.Size(40, 40);
            this.iconLogo.TabIndex = 0;
            this.iconLogo.Text = "";
            //
            // lblApp
            //
            this.lblApp.AutoSize = true;
            this.lblApp.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblApp.ForeColor = System.Drawing.Color.White;
            this.lblApp.Location = new System.Drawing.Point(68, 22);
            this.lblApp.Name = "lblApp";
            this.lblApp.TabIndex = 1;
            this.lblApp.Text = "Cabinet Médical";
            //
            // lblAppSub
            //
            this.lblAppSub.AutoSize = true;
            this.lblAppSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAppSub.ForeColor = TEST.Controls.Theme.TextDisabled;
            this.lblAppSub.Location = new System.Drawing.Point(69, 46);
            this.lblAppSub.Name = "lblAppSub";
            this.lblAppSub.TabIndex = 2;
            this.lblAppSub.Text = "Espace médecin";
            //
            // lblMenu
            //
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Segoe UI Semibold", 8.5F);
            this.lblMenu.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblMenu.Location = new System.Drawing.Point(24, 100);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.TabIndex = 3;
            this.lblMenu.Text = "MENU";
            //
            // btnAccueil
            //
            this.btnAccueil.IconGlyph = "";
            this.btnAccueil.Location = new System.Drawing.Point(12, 126);
            this.btnAccueil.Name = "btnAccueil";
            this.btnAccueil.Size = new System.Drawing.Size(216, 44);
            this.btnAccueil.TabIndex = 4;
            this.btnAccueil.Text = "Tableau de bord";
            this.btnAccueil.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnAccueil.Click += new System.EventHandler(this.btnAccueil_Click);
            //
            // btnPatients
            //
            this.btnPatients.IconGlyph = "";
            this.btnPatients.Location = new System.Drawing.Point(12, 174);
            this.btnPatients.Name = "btnPatients";
            this.btnPatients.Size = new System.Drawing.Size(216, 44);
            this.btnPatients.TabIndex = 5;
            this.btnPatients.Text = "Patients";
            this.btnPatients.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnPatients.Click += new System.EventHandler(this.btnPatients_Click);
            //
            // btnMedecins
            //
            this.btnMedecins.IconGlyph = "";
            this.btnMedecins.Location = new System.Drawing.Point(12, 222);
            this.btnMedecins.Name = "btnMedecins";
            this.btnMedecins.Size = new System.Drawing.Size(216, 44);
            this.btnMedecins.TabIndex = 6;
            this.btnMedecins.Text = "Médecins";
            this.btnMedecins.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnMedecins.Click += new System.EventHandler(this.btnMedecins_Click);
            //
            // btnMedicaments
            //
            this.btnMedicaments.IconGlyph = "";
            this.btnMedicaments.Location = new System.Drawing.Point(12, 270);
            this.btnMedicaments.Name = "btnMedicaments";
            this.btnMedicaments.Size = new System.Drawing.Size(216, 44);
            this.btnMedicaments.TabIndex = 7;
            this.btnMedicaments.Text = "Médicaments";
            this.btnMedicaments.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnMedicaments.Click += new System.EventHandler(this.btnMedicaments_Click);
            //
            // btnConsultations
            //
            this.btnConsultations.IconGlyph = "";
            this.btnConsultations.Location = new System.Drawing.Point(12, 318);
            this.btnConsultations.Name = "btnConsultations";
            this.btnConsultations.Size = new System.Drawing.Size(216, 44);
            this.btnConsultations.TabIndex = 8;
            this.btnConsultations.Text = "Consultations";
            this.btnConsultations.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnConsultations.Click += new System.EventHandler(this.btnConsultations_Click);
            //
            // lblUtilisateur
            //
            this.lblUtilisateur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblUtilisateur.AutoEllipsis = true;
            this.lblUtilisateur.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.lblUtilisateur.ForeColor = System.Drawing.Color.White;
            this.lblUtilisateur.Location = new System.Drawing.Point(24, 664);
            this.lblUtilisateur.Name = "lblUtilisateur";
            this.lblUtilisateur.Size = new System.Drawing.Size(200, 22);
            this.lblUtilisateur.TabIndex = 9;
            this.lblUtilisateur.Text = "Dr";
            //
            // lblRole
            //
            this.lblRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRole.ForeColor = TEST.Controls.Theme.TextDisabled;
            this.lblRole.Location = new System.Drawing.Point(24, 686);
            this.lblRole.Name = "lblRole";
            this.lblRole.TabIndex = 10;
            this.lblRole.Text = "Médecin connecté";
            //
            // btnDeconnexion
            //
            this.btnDeconnexion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeconnexion.IconGlyph = "";
            this.btnDeconnexion.Location = new System.Drawing.Point(12, 718);
            this.btnDeconnexion.Name = "btnDeconnexion";
            this.btnDeconnexion.Size = new System.Drawing.Size(216, 44);
            this.btnDeconnexion.TabIndex = 11;
            this.btnDeconnexion.Text = "Se déconnecter";
            this.btnDeconnexion.Variant = TEST.Controls.ButtonVariant.Nav;
            this.btnDeconnexion.Click += new System.EventHandler(this.btnDeconnexion_Click);
            //
            // panelContenu
            //
            this.panelContenu.BackColor = TEST.Controls.Theme.Background;
            this.panelContenu.Controls.Add(this.accueil1);
            this.panelContenu.Controls.Add(this.patient1);
            this.panelContenu.Controls.Add(this.medecin1);
            this.panelContenu.Controls.Add(this.medicament1);
            this.panelContenu.Controls.Add(this.consultation1);
            this.panelContenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenu.Location = new System.Drawing.Point(240, 0);
            this.panelContenu.Name = "panelContenu";
            this.panelContenu.Size = new System.Drawing.Size(1040, 780);
            this.panelContenu.TabIndex = 1;
            //
            // accueil1
            //
            this.accueil1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accueil1.Name = "accueil1";
            this.accueil1.TabIndex = 0;
            //
            // patient1
            //
            this.patient1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patient1.Name = "patient1";
            this.patient1.TabIndex = 1;
            //
            // medecin1
            //
            this.medecin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medecin1.Name = "medecin1";
            this.medecin1.TabIndex = 2;
            //
            // medicament1
            //
            this.medicament1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.medicament1.Name = "medicament1";
            this.medicament1.TabIndex = 3;
            //
            // consultation1
            //
            this.consultation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.consultation1.Name = "consultation1";
            this.consultation1.TabIndex = 4;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Background;
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.panelContenu);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabinet Médical";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelContenu.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private TEST.Controls.IconLabel iconLogo;
        private System.Windows.Forms.Label lblApp;
        private System.Windows.Forms.Label lblAppSub;
        private System.Windows.Forms.Label lblMenu;
        private TEST.Controls.FlatButton btnAccueil;
        private TEST.Controls.FlatButton btnPatients;
        private TEST.Controls.FlatButton btnMedecins;
        private TEST.Controls.FlatButton btnMedicaments;
        private TEST.Controls.FlatButton btnConsultations;
        private System.Windows.Forms.Label lblUtilisateur;
        private System.Windows.Forms.Label lblRole;
        private TEST.Controls.FlatButton btnDeconnexion;
        private System.Windows.Forms.Panel panelContenu;
        private accueil accueil1;
        private patient patient1;
        private medecin medecin1;
        private medicament medicament1;
        private consultation consultation1;
    }
}
