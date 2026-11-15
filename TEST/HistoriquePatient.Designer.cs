namespace TEST
{
    partial class HistoriquePatient
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
            this.panelEntete = new System.Windows.Forms.Panel();
            this.lblInfos = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.tableStats = new System.Windows.Forms.TableLayoutPanel();
            this.statTotal = new TEST.Controls.StatCard();
            this.statDerniere = new TEST.Controls.StatCard();
            this.statProchaine = new TEST.Controls.StatCard();
            this.statMontant = new TEST.Controls.StatCard();
            this.panelPied = new System.Windows.Forms.Panel();
            this.btnNouvelle = new TEST.Controls.FlatButton();
            this.btnFermer = new TEST.Controls.FlatButton();
            this.cardListe = new TEST.Controls.CardPanel();
            this.grid = new TEST.Controls.FlatDataGridView();
            this.lblListeSub = new System.Windows.Forms.Label();
            this.lblListe = new System.Windows.Forms.Label();
            this.panelEntete.SuspendLayout();
            this.tableStats.SuspendLayout();
            this.panelPied.SuspendLayout();
            this.cardListe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            //
            // panelEntete
            //
            this.panelEntete.Controls.Add(this.lblInfos);
            this.panelEntete.Controls.Add(this.lblNom);
            this.panelEntete.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEntete.Name = "panelEntete";
            this.panelEntete.Size = new System.Drawing.Size(884, 70);
            this.panelEntete.TabIndex = 0;
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI Semibold", 18F);
            this.lblNom.ForeColor = TEST.Controls.Theme.Text;
            this.lblNom.Location = new System.Drawing.Point(-4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.TabIndex = 0;
            this.lblNom.Text = "Patient";
            //
            // lblInfos
            //
            this.lblInfos.AutoSize = true;
            this.lblInfos.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblInfos.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblInfos.Location = new System.Drawing.Point(-1, 40);
            this.lblInfos.Name = "lblInfos";
            this.lblInfos.TabIndex = 1;
            this.lblInfos.Text = "CIN";
            //
            // tableStats
            //
            this.tableStats.ColumnCount = 4;
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableStats.Controls.Add(this.statTotal, 0, 0);
            this.tableStats.Controls.Add(this.statDerniere, 1, 0);
            this.tableStats.Controls.Add(this.statProchaine, 2, 0);
            this.tableStats.Controls.Add(this.statMontant, 3, 0);
            this.tableStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableStats.Name = "tableStats";
            this.tableStats.Padding = new System.Windows.Forms.Padding(0, 4, 0, 16);
            this.tableStats.RowCount = 1;
            this.tableStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableStats.Size = new System.Drawing.Size(884, 124);
            this.tableStats.TabIndex = 1;
            //
            // statTotal
            //
            this.statTotal.Accent = TEST.Controls.Theme.Primary;
            this.statTotal.AccentSoft = TEST.Controls.Theme.PrimarySoft;
            this.statTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statTotal.IconGlyph = "";
            this.statTotal.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statTotal.Name = "statTotal";
            this.statTotal.TabIndex = 0;
            this.statTotal.Titre = "Consultations";
            //
            // statDerniere
            //
            this.statDerniere.Accent = TEST.Controls.Theme.Violet;
            this.statDerniere.AccentSoft = TEST.Controls.Theme.VioletSoft;
            this.statDerniere.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statDerniere.IconGlyph = "";
            this.statDerniere.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statDerniere.Name = "statDerniere";
            this.statDerniere.TabIndex = 1;
            this.statDerniere.Titre = "Dernière visite";
            //
            // statProchaine
            //
            this.statProchaine.Accent = TEST.Controls.Theme.Warning;
            this.statProchaine.AccentSoft = TEST.Controls.Theme.WarningSoft;
            this.statProchaine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statProchaine.IconGlyph = "";
            this.statProchaine.Margin = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.statProchaine.Name = "statProchaine";
            this.statProchaine.TabIndex = 2;
            this.statProchaine.Titre = "Prochain RDV";
            //
            // statMontant
            //
            this.statMontant.Accent = TEST.Controls.Theme.Success;
            this.statMontant.AccentSoft = TEST.Controls.Theme.SuccessSoft;
            this.statMontant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statMontant.IconGlyph = "";
            this.statMontant.Margin = new System.Windows.Forms.Padding(0);
            this.statMontant.Name = "statMontant";
            this.statMontant.TabIndex = 3;
            this.statMontant.Titre = "Montant total";
            //
            // panelPied
            //
            this.panelPied.Controls.Add(this.btnNouvelle);
            this.panelPied.Controls.Add(this.btnFermer);
            this.panelPied.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelPied.Name = "panelPied";
            this.panelPied.Size = new System.Drawing.Size(884, 60);
            this.panelPied.TabIndex = 3;
            //
            // btnFermer
            //
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFermer.Location = new System.Drawing.Point(764, 18);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(120, 42);
            this.btnFermer.TabIndex = 1;
            this.btnFermer.Text = "Fermer";
            this.btnFermer.Variant = TEST.Controls.ButtonVariant.Secondary;
            //
            // btnNouvelle
            //
            this.btnNouvelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNouvelle.IconGlyph = "";
            this.btnNouvelle.Location = new System.Drawing.Point(536, 18);
            this.btnNouvelle.Name = "btnNouvelle";
            this.btnNouvelle.Size = new System.Drawing.Size(220, 42);
            this.btnNouvelle.TabIndex = 0;
            this.btnNouvelle.Text = "Nouvelle consultation";
            this.btnNouvelle.Click += new System.EventHandler(this.btnNouvelle_Click);
            //
            // cardListe
            //
            this.cardListe.Controls.Add(this.grid);
            this.cardListe.Controls.Add(this.lblListeSub);
            this.cardListe.Controls.Add(this.lblListe);
            this.cardListe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardListe.Name = "cardListe";
            this.cardListe.Size = new System.Drawing.Size(884, 360);
            this.cardListe.TabIndex = 2;
            //
            // lblListe
            //
            this.lblListe.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListe.Font = new System.Drawing.Font("Segoe UI Semibold", 12.5F);
            this.lblListe.ForeColor = TEST.Controls.Theme.Text;
            this.lblListe.Name = "lblListe";
            this.lblListe.Size = new System.Drawing.Size(844, 28);
            this.lblListe.TabIndex = 0;
            this.lblListe.Text = "Historique des consultations";
            //
            // lblListeSub
            //
            this.lblListeSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblListeSub.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblListeSub.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblListeSub.Name = "lblListeSub";
            this.lblListeSub.Size = new System.Drawing.Size(844, 32);
            this.lblListeSub.TabIndex = 1;
            this.lblListeSub.Text = "De la plus récente à la plus ancienne. Double-cliquez sur une consultation pour l'ouvrir.";
            //
            // grid
            //
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmptyText = "Aucune consultation pour ce patient";
            this.grid.Name = "grid";
            this.grid.TabIndex = 2;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            this.grid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grid_CellFormatting);
            //
            // HistoriquePatient
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Background;
            this.CancelButton = this.btnFermer;
            this.ClientSize = new System.Drawing.Size(940, 640);
            this.Controls.Add(this.cardListe);
            this.Controls.Add(this.panelPied);
            this.Controls.Add(this.tableStats);
            this.Controls.Add(this.panelEntete);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HistoriquePatient";
            this.Padding = new System.Windows.Forms.Padding(28, 24, 28, 20);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historique du patient";
            this.Load += new System.EventHandler(this.HistoriquePatient_Load);
            this.panelEntete.ResumeLayout(false);
            this.panelEntete.PerformLayout();
            this.tableStats.ResumeLayout(false);
            this.panelPied.ResumeLayout(false);
            this.cardListe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelEntete;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblInfos;
        private System.Windows.Forms.TableLayoutPanel tableStats;
        private TEST.Controls.StatCard statTotal;
        private TEST.Controls.StatCard statDerniere;
        private TEST.Controls.StatCard statProchaine;
        private TEST.Controls.StatCard statMontant;
        private System.Windows.Forms.Panel panelPied;
        private TEST.Controls.FlatButton btnNouvelle;
        private TEST.Controls.FlatButton btnFermer;
        private TEST.Controls.CardPanel cardListe;
        private System.Windows.Forms.Label lblListe;
        private System.Windows.Forms.Label lblListeSub;
        private TEST.Controls.FlatDataGridView grid;
    }
}
