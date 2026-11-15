namespace TEST
{
    partial class medecin
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
            this.txtTel = new TEST.Controls.FlatTextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.txtCin = new TEST.Controls.FlatTextBox();
            this.lblCin = new System.Windows.Forms.Label();
            this.txtNom = new TEST.Controls.FlatTextBox();
            this.lblNom = new System.Windows.Forms.Label();
            this.lblFormSub = new System.Windows.Forms.Label();
            this.lblForm = new System.Windows.Forms.Label();
            this.panelCorps.SuspendLayout();
            this.cardListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panelListeEntete.SuspendLayout();
            this.cardForm.SuspendLayout();
            this.SuspendLayout();
            //
            // lblTitre
            //
            this.lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitre.ForeColor = TEST.Controls.Theme.Text;
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(976, 42);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Médecins";
            //
            // lblSousTitre
            //
            this.lblSousTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSousTitre.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.Size = new System.Drawing.Size(976, 28);
            this.lblSousTitre.TabIndex = 1;
            this.lblSousTitre.Text = "Ajoutez, modifiez ou supprimez les fiches des médecins.";
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
            this.cardForm.Controls.Add(this.txtTel);
            this.cardForm.Controls.Add(this.lblTel);
            this.cardForm.Controls.Add(this.txtCin);
            this.cardForm.Controls.Add(this.lblCin);
            this.cardForm.Controls.Add(this.txtNom);
            this.cardForm.Controls.Add(this.lblNom);
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
            this.lblForm.Text = "Nouveau médecin";
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
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblNom.ForeColor = TEST.Controls.Theme.Text;
            this.lblNom.Location = new System.Drawing.Point(20, 86);
            this.lblNom.Name = "lblNom";
            this.lblNom.TabIndex = 2;
            this.lblNom.Text = "Nom complet";
            //
            // txtNom
            //
            this.txtNom.Location = new System.Drawing.Point(20, 108);
            this.txtNom.MaxLength = 100;
            this.txtNom.Name = "txtNom";
            this.txtNom.Placeholder = "ex. Youssef Alaoui";
            this.txtNom.Size = new System.Drawing.Size(300, 40);
            this.txtNom.TabIndex = 3;
            //
            // lblCin
            //
            this.lblCin.AutoSize = true;
            this.lblCin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblCin.ForeColor = TEST.Controls.Theme.Text;
            this.lblCin.Location = new System.Drawing.Point(20, 162);
            this.lblCin.Name = "lblCin";
            this.lblCin.TabIndex = 4;
            this.lblCin.Text = "CIN";
            //
            // txtCin
            //
            this.txtCin.Location = new System.Drawing.Point(20, 184);
            this.txtCin.MaxLength = 20;
            this.txtCin.Name = "txtCin";
            this.txtCin.Placeholder = "ex. AB123456";
            this.txtCin.Size = new System.Drawing.Size(300, 40);
            this.txtCin.TabIndex = 5;
            //
            // lblTel
            //
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblTel.ForeColor = TEST.Controls.Theme.Text;
            this.lblTel.Location = new System.Drawing.Point(20, 238);
            this.lblTel.Name = "lblTel";
            this.lblTel.TabIndex = 6;
            this.lblTel.Text = "Téléphone";
            //
            // txtTel
            //
            this.txtTel.Location = new System.Drawing.Point(20, 260);
            this.txtTel.MaxLength = 20;
            this.txtTel.Name = "txtTel";
            this.txtTel.Placeholder = "ex. 0612345678";
            this.txtTel.Size = new System.Drawing.Size(300, 40);
            this.txtTel.TabIndex = 7;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            //
            // btnAjouter
            //
            this.btnAjouter.IconGlyph = "";
            this.btnAjouter.Location = new System.Drawing.Point(20, 326);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(300, 42);
            this.btnAjouter.TabIndex = 8;
            this.btnAjouter.Text = "Ajouter le médecin";
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            //
            // btnModifier
            //
            this.btnModifier.IconGlyph = "";
            this.btnModifier.Location = new System.Drawing.Point(20, 326);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(146, 42);
            this.btnModifier.TabIndex = 9;
            this.btnModifier.Text = "Enregistrer";
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            //
            // btnSupprimer
            //
            this.btnSupprimer.IconGlyph = "";
            this.btnSupprimer.Location = new System.Drawing.Point(174, 326);
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
            this.btnNouveau.Location = new System.Drawing.Point(20, 376);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(300, 38);
            this.btnNouveau.TabIndex = 11;
            this.btnNouveau.Text = "Effacer le formulaire";
            this.btnNouveau.Variant = TEST.Controls.ButtonVariant.Ghost;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            //
            // lblStatut
            //
            this.lblStatut.Location = new System.Drawing.Point(20, 430);
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
            this.lblListe.Text = "Liste des médecins";
            //
            // lblCompte
            //
            this.lblCompte.AutoSize = true;
            this.lblCompte.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCompte.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblCompte.Location = new System.Drawing.Point(0, 26);
            this.lblCompte.Name = "lblCompte";
            this.lblCompte.TabIndex = 1;
            this.lblCompte.Text = "0 médecin";
            //
            // txtRecherche
            //
            this.txtRecherche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRecherche.IconGlyph = "";
            this.txtRecherche.Location = new System.Drawing.Point(296, 0);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.Placeholder = "Rechercher (nom, CIN, téléphone)";
            this.txtRecherche.Size = new System.Drawing.Size(280, 40);
            this.txtRecherche.TabIndex = 2;
            this.txtRecherche.TextChanged += new System.EventHandler(this.txtRecherche_TextChanged);
            //
            // grid
            //
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmptyText = "Aucun médecin trouvé";
            this.grid.Name = "grid";
            this.grid.TabIndex = 1;
            this.grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellClick);
            //
            // medecin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Background;
            this.Controls.Add(this.panelCorps);
            this.Controls.Add(this.lblSousTitre);
            this.Controls.Add(this.lblTitre);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "medecin";
            this.Padding = new System.Windows.Forms.Padding(32, 28, 32, 32);
            this.Size = new System.Drawing.Size(1040, 780);
            this.Load += new System.EventHandler(this.medecin_Load);
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
        private System.Windows.Forms.Panel panelCorps;
        private TEST.Controls.CardPanel cardForm;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.Label lblFormSub;
        private System.Windows.Forms.Label lblNom;
        private TEST.Controls.FlatTextBox txtNom;
        private System.Windows.Forms.Label lblCin;
        private TEST.Controls.FlatTextBox txtCin;
        private System.Windows.Forms.Label lblTel;
        private TEST.Controls.FlatTextBox txtTel;
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
