namespace TEST
{
    partial class signup
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
            this.panelMarque = new System.Windows.Forms.Panel();
            this.lblSlogan = new System.Windows.Forms.Label();
            this.lblMarque = new System.Windows.Forms.Label();
            this.iconMarque = new TEST.Controls.IconLabel();
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblSousTitre = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.txtNom = new TEST.Controls.FlatTextBox();
            this.lblCin = new System.Windows.Forms.Label();
            this.txtCin = new TEST.Controls.FlatTextBox();
            this.lblErreur = new System.Windows.Forms.Label();
            this.btnConnexion = new TEST.Controls.FlatButton();
            this.panelMarque.SuspendLayout();
            this.SuspendLayout();
            //
            // panelMarque
            //
            this.panelMarque.BackColor = TEST.Controls.Theme.Primary;
            this.panelMarque.Controls.Add(this.lblSlogan);
            this.panelMarque.Controls.Add(this.lblMarque);
            this.panelMarque.Controls.Add(this.iconMarque);
            this.panelMarque.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMarque.Location = new System.Drawing.Point(0, 0);
            this.panelMarque.Name = "panelMarque";
            this.panelMarque.Size = new System.Drawing.Size(380, 540);
            this.panelMarque.TabIndex = 0;
            //
            // iconMarque
            //
            this.iconMarque.Font = new System.Drawing.Font("Segoe MDL2 Assets", 40F);
            this.iconMarque.ForeColor = System.Drawing.Color.White;
            this.iconMarque.Location = new System.Drawing.Point(40, 150);
            this.iconMarque.Name = "iconMarque";
            this.iconMarque.Size = new System.Drawing.Size(80, 80);
            this.iconMarque.TabIndex = 0;
            this.iconMarque.Text = "";
            this.iconMarque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblMarque
            //
            this.lblMarque.AutoSize = true;
            this.lblMarque.Font = new System.Drawing.Font("Segoe UI Semibold", 24F);
            this.lblMarque.ForeColor = System.Drawing.Color.White;
            this.lblMarque.Location = new System.Drawing.Point(34, 240);
            this.lblMarque.Name = "lblMarque";
            this.lblMarque.TabIndex = 1;
            this.lblMarque.Text = "Cabinet Médical";
            //
            // lblSlogan
            //
            this.lblSlogan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSlogan.ForeColor = TEST.Controls.Theme.PrimarySoft;
            this.lblSlogan.Location = new System.Drawing.Point(40, 296);
            this.lblSlogan.Name = "lblSlogan";
            this.lblSlogan.Size = new System.Drawing.Size(300, 60);
            this.lblSlogan.TabIndex = 2;
            this.lblSlogan.Text = "Patients, médecins et consultations, au même endroit.";
            //
            // lblTitre
            //
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI Semibold", 20F);
            this.lblTitre.ForeColor = TEST.Controls.Theme.Text;
            this.lblTitre.Location = new System.Drawing.Point(446, 120);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.TabIndex = 1;
            this.lblTitre.Text = "Connexion";
            //
            // lblSousTitre
            //
            this.lblSousTitre.AutoSize = true;
            this.lblSousTitre.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSousTitre.ForeColor = TEST.Controls.Theme.TextMuted;
            this.lblSousTitre.Location = new System.Drawing.Point(450, 166);
            this.lblSousTitre.Name = "lblSousTitre";
            this.lblSousTitre.TabIndex = 2;
            this.lblSousTitre.Text = "Entrez votre nom et votre CIN pour continuer.";
            //
            // lblNom
            //
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblNom.ForeColor = TEST.Controls.Theme.Text;
            this.lblNom.Location = new System.Drawing.Point(450, 220);
            this.lblNom.Name = "lblNom";
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "Nom du médecin";
            //
            // txtNom
            //
            this.txtNom.IconGlyph = "";
            this.txtNom.Location = new System.Drawing.Point(450, 244);
            this.txtNom.Name = "txtNom";
            this.txtNom.Placeholder = "Votre nom";
            this.txtNom.Size = new System.Drawing.Size(360, 42);
            this.txtNom.TabIndex = 4;
            //
            // lblCin
            //
            this.lblCin.AutoSize = true;
            this.lblCin.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F);
            this.lblCin.ForeColor = TEST.Controls.Theme.Text;
            this.lblCin.Location = new System.Drawing.Point(450, 302);
            this.lblCin.Name = "lblCin";
            this.lblCin.TabIndex = 5;
            this.lblCin.Text = "CIN";
            //
            // txtCin
            //
            this.txtCin.IconGlyph = "";
            this.txtCin.Location = new System.Drawing.Point(450, 326);
            this.txtCin.Name = "txtCin";
            this.txtCin.PasswordChar = '●';
            this.txtCin.Placeholder = "Votre numéro de CIN";
            this.txtCin.Size = new System.Drawing.Size(360, 42);
            this.txtCin.TabIndex = 6;
            //
            // lblErreur
            //
            this.lblErreur.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblErreur.ForeColor = TEST.Controls.Theme.Danger;
            this.lblErreur.Location = new System.Drawing.Point(450, 376);
            this.lblErreur.Name = "lblErreur";
            this.lblErreur.Size = new System.Drawing.Size(360, 24);
            this.lblErreur.TabIndex = 7;
            this.lblErreur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // btnConnexion
            //
            this.btnConnexion.Location = new System.Drawing.Point(450, 408);
            this.btnConnexion.Name = "btnConnexion";
            this.btnConnexion.Size = new System.Drawing.Size(360, 46);
            this.btnConnexion.TabIndex = 8;
            this.btnConnexion.Text = "Se connecter";
            this.btnConnexion.Click += new System.EventHandler(this.btnConnexion_Click);
            //
            // signup
            //
            this.AcceptButton = this.btnConnexion;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = TEST.Controls.Theme.Surface;
            this.ClientSize = new System.Drawing.Size(880, 540);
            this.Controls.Add(this.btnConnexion);
            this.Controls.Add(this.lblErreur);
            this.Controls.Add(this.txtCin);
            this.Controls.Add(this.lblCin);
            this.Controls.Add(this.txtNom);
            this.Controls.Add(this.lblNom);
            this.Controls.Add(this.lblSousTitre);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.panelMarque);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "signup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabinet Médical — Connexion";
            this.panelMarque.ResumeLayout(false);
            this.panelMarque.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelMarque;
        private TEST.Controls.IconLabel iconMarque;
        private System.Windows.Forms.Label lblMarque;
        private System.Windows.Forms.Label lblSlogan;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblSousTitre;
        private System.Windows.Forms.Label lblNom;
        private TEST.Controls.FlatTextBox txtNom;
        private System.Windows.Forms.Label lblCin;
        private TEST.Controls.FlatTextBox txtCin;
        private System.Windows.Forms.Label lblErreur;
        private TEST.Controls.FlatButton btnConnexion;
    }
}
