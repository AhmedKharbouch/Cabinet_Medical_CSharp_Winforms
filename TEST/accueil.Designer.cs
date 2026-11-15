namespace TEST
{
    partial class accueil
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
            this.tableStats = new System.Windows.Forms.TableLayoutPanel();
            this.statPatients = new TEST.Controls.StatCard();
            this.statMedecins = new TEST.Controls.StatCard();
            this.statAujourdhui = new TEST.Controls.StatCard();
            this.statRecettes = new TEST.Controls.StatCard();
            this.cardProchaines = new TEST.Controls.CardPanel();
            this.gridProchaines = new TEST.Controls.FlatDataGridView();
            this.calendrierProchaines = new TEST.Controls.CalendarView();
            this.btnVueCalendrier = new TEST.Controls.FlatButton();
            this.btnVueListe = new TEST.Controls.FlatButton();
            this.lblProchainesSub = new System.Windows.Forms.Label();
            this.lblProchaines = new System.Windows.Forms.Label();
            this.tableStats.SuspendLayout();
            this.cardProchaines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProchaines)).BeginInit();
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
            this.lblTitre.Text = "Tableau de bord";
            //
            // lblSousTitre
            //
            this.lblSousTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSousTitre.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.Size = new System.Drawing.Size(976, 28);
            this.lblSousTitre.TabIndex = 1;
            this.lblSousTitre.Text = "Bonjour";
            //
            // tableStats
            //
            this.tableStats.ColumnCount = 4;
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.Controls.Add(this.statPatients, 0, 0);
            this.tableStats.Controls.Add(this.statMedecins, 1, 0);
            this.tableStats.Controls.Add(this.statAujourdhui, 2, 0);
            this.tableStats.Controls.Add(this.statRecettes, 3, 0);
            this.tableStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableStats.Name = "tableStats";
            this.tableStats.Padding = new System.Windows.Forms.Padding(0, 18, 0, 18);
            this.tableStats.RowCount = 1;
            this.tableStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableStats.Size = new System.Drawing.Size(976, 150);
            this.tableStats.TabIndex = 2;
            //
            // statPatients
            //
            this.statPatients.Accent = TEST.Controls.Theme.Primary;
            this.statPatients.AccentSoft = TEST.Controls.Theme.PrimarySoft;
            this.statPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statPatients.IconGlyph = "";
            this.statPatients.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.statPatients.Name = "statPatients";
            this.statPatients.TabIndex = 0;
            this.statPatients.Titre = "Patients";
            //
            // statMedecins
            //
            this.statMedecins.Accent = TEST.Controls.Theme.Violet;
            this.statMedecins.AccentSoft = TEST.Controls.Theme.VioletSoft;
            this.statMedecins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statMedecins.IconGlyph = "";
            this.statMedecins.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.statMedecins.Name = "statMedecins";
            this.statMedecins.TabIndex = 1;
            this.statMedecins.Titre = "Médecins";
            //
            // statAujourdhui
            //
            this.statAujourdhui.Accent = TEST.Controls.Theme.Warning;
            this.statAujourdhui.AccentSoft = TEST.Controls.Theme.WarningSoft;
            this.statAujourdhui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statAujourdhui.IconGlyph = "";
            this.statAujourdhui.Margin = new System.Windows.Forms.Padding(0, 0, 16, 0);
            this.statAujourdhui.Name = "statAujourdhui";
            this.statAujourdhui.TabIndex = 2;
            this.statAujourdhui.Titre = "Rendez-vous du jour";
            //
            // statRecettes
            //
            this.statRecettes.Accent = TEST.Controls.Theme.Success;
            this.statRecettes.AccentSoft = TEST.Controls.Theme.SuccessSoft;
            this.statRecettes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statRecettes.IconGlyph = "";
            this.statRecettes.Margin = new System.Windows.Forms.Padding(0);
            this.statRecettes.Name = "statRecettes";
            this.statRecettes.TabIndex = 3;
            this.statRecettes.Titre = "Recettes du mois";
            //
            // cardProchaines
            //
            this.cardProchaines.Controls.Add(this.btnVueListe);
            this.cardProchaines.Controls.Add(this.btnVueCalendrier);
            this.cardProchaines.Controls.Add(this.calendrierProchaines);
            this.cardProchaines.Controls.Add(this.gridProchaines);
            this.cardProchaines.Controls.Add(this.lblProchainesSub);
            this.cardProchaines.Controls.Add(this.lblProchaines);
            this.cardProchaines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardProchaines.Name = "cardProchaines";
            this.cardProchaines.Size = new System.Drawing.Size(976, 500);
            this.cardProchaines.TabIndex = 3;
            //
            // lblProchaines
            //
            this.lblProchaines.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProchaines.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblProchaines.ForeColor = TEST.Controls.Theme.Text;
            this.lblProchaines.Name = "lblProchaines";
            this.lblProchaines.Size = new System.Drawing.Size(936, 28);
            this.lblProchaines.TabIndex = 0;
            this.lblProchaines.Text = "Prochaines consultations";
            //
            // lblProchainesSub
            //
            this.lblProchainesSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProchainesSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblProchainesSub.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblProchainesSub.Name = "lblProchainesSub";
            this.lblProchainesSub.Size = new System.Drawing.Size(936, 34);
            this.lblProchainesSub.TabIndex = 1;
            this.lblProchainesSub.Text = "Les 20 prochains rendez-vous, à partir d'aujourd'hui.";
            // 
            // btnVueCalendrier
            // 
            this.btnVueCalendrier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVueCalendrier.IconGlyph = "";
            this.btnVueCalendrier.Location = new System.Drawing.Point(728, 18);
            this.btnVueCalendrier.Name = "btnVueCalendrier";
            this.btnVueCalendrier.Size = new System.Drawing.Size(124, 36);
            this.btnVueCalendrier.TabIndex = 3;
            this.btnVueCalendrier.Text = "Calendrier";
            this.btnVueCalendrier.Variant = TEST.Controls.ButtonVariant.Secondary;
            this.btnVueCalendrier.Click += new System.EventHandler(this.btnVueCalendrier_Click);
            // 
            // btnVueListe
            // 
            this.btnVueListe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVueListe.IconGlyph = "";
            this.btnVueListe.Location = new System.Drawing.Point(860, 18);
            this.btnVueListe.Name = "btnVueListe";
            this.btnVueListe.Size = new System.Drawing.Size(96, 36);
            this.btnVueListe.TabIndex = 4;
            this.btnVueListe.Text = "Liste";
            this.btnVueListe.Click += new System.EventHandler(this.btnVueListe_Click);
            // 
            // calendrierProchaines
            // 
            this.calendrierProchaines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendrierProchaines.Name = "calendrierProchaines";
            this.calendrierProchaines.TabIndex = 5;
            this.calendrierProchaines.Visible = false;
            this.calendrierProchaines.EvenementClique += new System.EventHandler<TEST.Controls.CalendrierEventArgs>(this.calendrierProchaines_EvenementClique);
            this.calendrierProchaines.JourClique += new System.EventHandler<TEST.Controls.CalendrierEventArgs>(this.calendrierProchaines_JourClique);
            //
            // gridProchaines
            //
            this.gridProchaines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridProchaines.EmptyText = "Aucune consultation à venir";
            this.gridProchaines.Name = "gridProchaines";
            this.gridProchaines.TabIndex = 2;
            this.gridProchaines.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProchaines_CellClick);
            //
            // accueil
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Background;
            this.Controls.Add(this.cardProchaines);
            this.Controls.Add(this.tableStats);
            this.Controls.Add(this.lblSousTitre);
            this.Controls.Add(this.lblTitre);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "accueil";
            this.Padding = new System.Windows.Forms.Padding(32, 28, 32, 32);
            this.Size = new System.Drawing.Size(1040, 780);
            this.Load += new System.EventHandler(this.accueil_Load);
            this.tableStats.ResumeLayout(false);
            this.cardProchaines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProchaines)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblSousTitre;
        private System.Windows.Forms.TableLayoutPanel tableStats;
        private TEST.Controls.StatCard statPatients;
        private TEST.Controls.StatCard statMedecins;
        private TEST.Controls.StatCard statAujourdhui;
        private TEST.Controls.StatCard statRecettes;
        private TEST.Controls.CardPanel cardProchaines;
        private System.Windows.Forms.Label lblProchaines;
        private System.Windows.Forms.Label lblProchainesSub;
        private TEST.Controls.FlatDataGridView gridProchaines;
        private TEST.Controls.CalendarView calendrierProchaines;
        private TEST.Controls.FlatButton btnVueCalendrier;
        private TEST.Controls.FlatButton btnVueListe;
    }
}
