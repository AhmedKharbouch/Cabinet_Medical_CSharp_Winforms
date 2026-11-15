namespace TEST
{
    partial class consultation
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

        #region Code généré par le Concepteur de composants

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblSousTitre = new System.Windows.Forms.Label();
            this.panelEntete = new System.Windows.Forms.Panel();
            this.btnVueCalendrier = new TEST.Controls.FlatButton();
            this.btnVueListe = new TEST.Controls.FlatButton();
            this.calendrier = new TEST.Controls.CalendarView();
            this.panelCorps = new System.Windows.Forms.Panel();
            this.cardListe = new TEST.Controls.CardPanel();
            this.grid = new TEST.Controls.FlatDataGridView();
            this.panelListeEntete = new System.Windows.Forms.Panel();
            this.txtRecherche = new TEST.Controls.FlatTextBox();
            this.lblCompte = new System.Windows.Forms.Label();
            this.lblListe = new System.Windows.Forms.Label();
            this.panelEcart = new System.Windows.Forms.Panel();
            this.cardForm = new TEST.Controls.CardPanel();
            this.lblStatut = new TEST.Controls.StatusLabel();
            this.btnNouveau = new TEST.Controls.FlatButton();
            this.btnSupprimer = new TEST.Controls.FlatButton();
            this.btnModifier = new TEST.Controls.FlatButton();
            this.btnAjouter = new TEST.Controls.FlatButton();
            this.txtPrix = new TEST.Controls.FlatTextBox();
            this.lblPrix = new System.Windows.Forms.Label();
            this.dtpDate = new TEST.Controls.FlatDateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboMedecin = new TEST.Controls.FlatComboBox();
            this.lblMedecin = new System.Windows.Forms.Label();
            this.cboPatient = new TEST.Controls.FlatComboBox();
            this.lblPatient = new System.Windows.Forms.Label();
            this.lblFormSub = new System.Windows.Forms.Label();
            this.lblForm = new System.Windows.Forms.Label();
            this.panelEntete.SuspendLayout();
            this.panelCorps.SuspendLayout();
            this.cardListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelListeEntete.SuspendLayout();
            this.cardForm.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitre
            //
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitre.ForeColor = TEST.Controls.Theme.Text;
            this.lblTitre.Location = new System.Drawing.Point(-4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Consultations";
            //
            // lblSousTitre
            //
            this.lblSousTitre.AutoSize = true;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSousTitre.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblSousTitre.Location = new System.Drawing.Point(-1, 44);
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.TabIndex = 1;
            this.lblSousTitre.Text = "Planifiez les rendez-vous et suivez les consultations.";
            // 
            // panelEntete
            // 
            this.panelEntete.Controls.Add(this.btnVueListe);
            this.panelEntete.Controls.Add(this.btnVueCalendrier);
            this.panelEntete.Controls.Add(this.lblSousTitre);
            this.panelEntete.Controls.Add(this.lblTitre);
            this.panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntete.Name = "panelEntete";
            this.panelEntete.Size = new System.Drawing.Size(976, 72);
            this.panelEntete.TabIndex = 0;
            // 
            // btnVueCalendrier
            // 
            this.btnVueCalendrier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVueCalendrier.IconGlyph = "";
            this.btnVueCalendrier.Location = new System.Drawing.Point(726, 14);
            this.btnVueCalendrier.Name = "btnVueCalendrier";
            this.btnVueCalendrier.Size = new System.Drawing.Size(130, 40);
            this.btnVueCalendrier.TabIndex = 2;
            this.btnVueCalendrier.Text = "Calendrier";
            this.btnVueCalendrier.Click += new System.EventHandler(this.btnVueCalendrier_Click);
            // 
            // btnVueListe
            // 
            this.btnVueListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVueListe.IconGlyph = "";
            this.btnVueListe.Location = new System.Drawing.Point(864, 14);
            this.btnVueListe.Name = "btnVueListe";
            this.btnVueListe.Size = new System.Drawing.Size(112, 40);
            this.btnVueListe.TabIndex = 3;
            this.btnVueListe.Text = "Liste";
            this.btnVueListe.Variant = TEST.Controls.ButtonVariant.Secondary;
            this.btnVueListe.Click += new System.EventHandler(this.btnVueListe_Click);
            // 
            // panelCorps
            //
            this.panelCorps.Controls.Add(this.cardListe);
            this.panelCorps.Controls.Add(this.panelEcart);
            this.panelCorps.Controls.Add(this.cardForm);
            this.panelCorps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCorps.Name = "panelCorps";
            this.panelCorps.Padding = new System.Windows.Forms.Padding(0, 18, 0, 0);
            this.panelCorps.Size = new System.Drawing.Size(976, 650);
            this.panelCorps.TabIndex = 2;
            //
            // cardForm
            //
            this.cardForm.Controls.Add(this.lblStatut);
            this.cardForm.Controls.Add(this.btnNouveau);
            this.cardForm.Controls.Add(this.btnSupprimer);
            this.cardForm.Controls.Add(this.btnModifier);
            this.cardForm.Controls.Add(this.btnAjouter);
            this.cardForm.Controls.Add(this.txtPrix);
            this.cardForm.Controls.Add(this.lblPrix);
            this.cardForm.Controls.Add(this.dtpDate);
            this.cardForm.Controls.Add(this.lblDate);
            this.cardForm.Controls.Add(this.cboMedecin);
            this.cardForm.Controls.Add(this.lblMedecin);
            this.cardForm.Controls.Add(this.cboPatient);
            this.cardForm.Controls.Add(this.lblPatient);
            this.cardForm.Controls.Add(this.lblFormSub);
            this.cardForm.Controls.Add(this.lblForm);
            this.cardForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.cardForm.Name = "cardForm";
            this.cardForm.Size = new System.Drawing.Size(340, 632);
            this.cardForm.TabIndex = 0;
            //
            // lblForm
            //
            this.lblForm.AutoSize = true;
            this.lblForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblForm.ForeColor = TEST.Controls.Theme.Text;
            this.lblForm.Location = new System.Drawing.Point(18, 18);
            this.lblForm.Name = "lblForm";
            this.lblForm.TabIndex = 0;
            this.lblForm.Text = "Nouvelle consultation";
            //
            // lblFormSub
            //
            this.lblFormSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFormSub.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblFormSub.Location = new System.Drawing.Point(20, 46);
            this.lblFormSub.Name = "lblFormSub";
            this.lblFormSub.Size = new System.Drawing.Size(300, 20);
            this.lblFormSub.TabIndex = 1;
            this.lblFormSub.Text = "Remplissez les informations ci-dessous.";
            // 
            // lblPatient
            // 
            this.lblPatient.AutoSize = true;
            this.lblPatient.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblPatient.ForeColor = TEST.Controls.Theme.Text;
            this.lblPatient.Location = new System.Drawing.Point(20, 86);
            this.lblPatient.Name = "lblPatient";
            this.lblPatient.TabIndex = 2;
            this.lblPatient.Text = "Patient";
            // 
            // cboPatient
            // 
            this.cboPatient.Location = new System.Drawing.Point(20, 108);
            this.cboPatient.Name = "cboPatient";
            this.cboPatient.Placeholder = "Choisir un patient";
            this.cboPatient.Size = new System.Drawing.Size(300, 40);
            this.cboPatient.TabIndex = 3;
            // 
            // lblMedecin
            // 
            this.lblMedecin.AutoSize = true;
            this.lblMedecin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblMedecin.ForeColor = TEST.Controls.Theme.Text;
            this.lblMedecin.Location = new System.Drawing.Point(20, 162);
            this.lblMedecin.Name = "lblMedecin";
            this.lblMedecin.TabIndex = 4;
            this.lblMedecin.Text = "Médecin";
            // 
            // cboMedecin
            // 
            this.cboMedecin.Location = new System.Drawing.Point(20, 184);
            this.cboMedecin.Name = "cboMedecin";
            this.cboMedecin.Placeholder = "Choisir un médecin";
            this.cboMedecin.Size = new System.Drawing.Size(300, 40);
            this.cboMedecin.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblDate.ForeColor = TEST.Controls.Theme.Text;
            this.lblDate.Location = new System.Drawing.Point(20, 238);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Date et heure";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(20, 260);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Placeholder = "Choisir une date";
            this.dtpDate.Size = new System.Drawing.Size(300, 40);
            this.dtpDate.TabIndex = 7;
            // 
            // lblPrix
            // 
            this.lblPrix.AutoSize = true;
            this.lblPrix.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblPrix.ForeColor = TEST.Controls.Theme.Text;
            this.lblPrix.Location = new System.Drawing.Point(20, 314);
            this.lblPrix.Name = "lblPrix";
            this.lblPrix.TabIndex = 8;
            this.lblPrix.Text = "Prix";
            // 
            // txtPrix
            // 
            this.txtPrix.Location = new System.Drawing.Point(20, 336);
            this.txtPrix.MaxLength = 7;
            this.txtPrix.Name = "txtPrix";
            this.txtPrix.Placeholder = "ex. 300";
            this.txtPrix.Size = new System.Drawing.Size(300, 40);
            this.txtPrix.TabIndex = 9;
            this.txtPrix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrix_KeyPress);
            //
            // btnAjouter
            //
            this.btnAjouter.IconGlyph = "";
            this.btnAjouter.Location = new System.Drawing.Point(20, 402);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(300, 42);
            this.btnAjouter.TabIndex = 10;
            this.btnAjouter.Text = "Ajouter la consultation";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            //
            // btnModifier
            //
            this.btnModifier.IconGlyph = "";
            this.btnModifier.Location = new System.Drawing.Point(20, 402);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(146, 42);
            this.btnModifier.TabIndex = 9;
            this.btnModifier.Text = "Enregistrer";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.IconGlyph = "";
            this.btnSupprimer.Location = new System.Drawing.Point(174, 402);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(146, 42);
            this.btnSupprimer.TabIndex = 10;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.Variant = TEST.Controls.ButtonVariant.Danger;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            //
            // btnNouveau
            //
            this.btnNouveau.IconGlyph = "";
            this.btnNouveau.Location = new System.Drawing.Point(20, 452);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(300, 38);
            this.btnNouveau.TabIndex = 11;
            this.btnNouveau.Text = "Effacer le formulaire";
            this.btnNouveau.Variant = TEST.Controls.ButtonVariant.Ghost;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            //
            // lblStatut
            //
            this.lblStatut.Location = new System.Drawing.Point(20, 506);
            this.lblStatut.Name = "lblStatut";
            this.lblStatut.Size = new System.Drawing.Size(300, 44);
            this.lblStatut.TabIndex = 12;
            //
            // panelEcart
            //
            this.panelEcart.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEcart.Name = "panelEcart";
            this.panelEcart.Size = new System.Drawing.Size(20, 632);
            this.panelEcart.TabIndex = 1;
            //
            // cardListe
            //
            this.cardListe.Controls.Add(this.calendrier);
            this.cardListe.Controls.Add(this.grid);
            this.cardListe.Controls.Add(this.panelListeEntete);
            this.cardListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardListe.Name = "cardListe";
            this.cardListe.Size = new System.Drawing.Size(616, 632);
            this.cardListe.TabIndex = 2;
            //
            // panelListeEntete
            //
            this.panelListeEntete.BackColor = TEST.Controls.Theme.Surface;
            this.panelListeEntete.Controls.Add(this.txtRecherche);
            this.panelListeEntete.Controls.Add(this.lblCompte);
            this.panelListeEntete.Controls.Add(this.lblListe);
            this.panelListeEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelListeEntete.Name = "panelListeEntete";
            this.panelListeEntete.Size = new System.Drawing.Size(576, 64);
            this.panelListeEntete.TabIndex = 0;
            //
            // lblListe
            //
            this.lblListe.AutoSize = true;
            this.lblListe.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblListe.ForeColor = TEST.Controls.Theme.Text;
            this.lblListe.Location = new System.Drawing.Point(-2, -2);
            this.lblListe.Name = "lblListe";
            this.lblListe.TabIndex = 0;
            this.lblListe.Text = "Liste des consultations";
            //
            // lblCompte
            //
            this.lblCompte.AutoSize = true;
            this.lblCompte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompte.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblCompte.Location = new System.Drawing.Point(0, 26);
            this.lblCompte.Name = "lblCompte";
            this.lblCompte.TabIndex = 1;
            this.lblCompte.Text = "0 consultation";
            //
            // txtRecherche
            //
            this.txtRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecherche.IconGlyph = "";
            this.txtRecherche.Location = new System.Drawing.Point(296, 0);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Placeholder = "Rechercher (patient, médecin)";
            this.txtRecherche.Size = new System.Drawing.Size(280, 40);
            this.txtRecherche.TabIndex = 2;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            // 
            // calendrier
            // 
            this.calendrier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendrier.Name = "calendrier";
            this.calendrier.TabIndex = 2;
            this.calendrier.EvenementClique += new System.EventHandler<TEST.Controls.CalendrierEventArgs>(this.calendrier_EvenementClique);
            this.calendrier.JourClique += new System.EventHandler<TEST.Controls.CalendrierEventArgs>(this.calendrier_JourClique);
            this.calendrier.MoisChange += new System.EventHandler(this.calendrier_MoisChange);
            //
            // grid
            //
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmptyText = "Aucune consultation trouvée";
            this.grid.Name = "grid";
            this.grid.TabIndex = 1;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            //
            // consultation
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Background;
            this.Controls.Add(this.panelCorps);
            this.Controls.Add(this.panelEntete);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "consultation";
            this.Padding = new System.Windows.Forms.Padding(32, 28, 32, 32);
            this.Size = new System.Drawing.Size(1040, 780);
            this.Load += new System.EventHandler(this.consultation_Load);
            this.panelEntete.ResumeLayout(false);
            this.panelEntete.PerformLayout();
            this.panelCorps.ResumeLayout(false);
            this.cardListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panelListeEntete.ResumeLayout(false);
            this.panelListeEntete.PerformLayout();
            this.cardForm.ResumeLayout(false);
            this.cardForm.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblSousTitre;
        private System.Windows.Forms.Panel panelEntete;
        private TEST.Controls.FlatButton btnVueCalendrier;
        private TEST.Controls.FlatButton btnVueListe;
        private TEST.Controls.CalendarView calendrier;
        private System.Windows.Forms.Panel panelCorps;
        private TEST.Controls.CardPanel cardForm;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblFormSub;
        private System.Windows.Forms.Label lblPatient;
        private TEST.Controls.FlatComboBox cboPatient;
        private System.Windows.Forms.Label lblMedecin;
        private TEST.Controls.FlatComboBox cboMedecin;
        private System.Windows.Forms.Label lblDate;
        private TEST.Controls.FlatDateTimePicker dtpDate;
        private System.Windows.Forms.Label lblPrix;
        private TEST.Controls.FlatTextBox txtPrix;
        private TEST.Controls.FlatButton btnAjouter;
        private TEST.Controls.FlatButton btnModifier;
        private TEST.Controls.FlatButton btnSupprimer;
        private TEST.Controls.FlatButton btnNouveau;
        private TEST.Controls.StatusLabel lblStatut;
        private System.Windows.Forms.Panel panelEcart;
        private TEST.Controls.CardPanel cardListe;
        private System.Windows.Forms.Panel panelListeEntete;
        private System.Windows.Forms.Label lblListe;
        private System.Windows.Forms.Label lblCompte;
        private TEST.Controls.FlatTextBox txtRecherche;
        private TEST.Controls.FlatDataGridView grid;
    }
}
