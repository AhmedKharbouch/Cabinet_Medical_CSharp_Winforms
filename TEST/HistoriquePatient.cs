using System;
using System.Data;
using System.Windows.Forms;
using TEST.Controls;

namespace TEST
{
    /// <summary>
    /// Fenêtre « Historique du patient » : résumé et liste de toutes ses consultations.
    /// Après fermeture, <see cref="ConsultationChoisie"/> ou <see cref="NouvelleDemandee"/>
    /// indiquent ce que l'utilisateur veut faire ensuite.
    /// </summary>
    public partial class HistoriquePatient : Form
    {
        private readonly int idPatient;

        public HistoriquePatient(int idPatient, string nom, string cin, string telephone)
        {
            InitializeComponent();
            this.idPatient = idPatient;
            lblNom.Text = nom;
            lblInfos.Text = "CIN " + cin + "   ·   Tél. " + telephone;
            Text = "Historique — " + nom;
        }

        /// <summary>Id de la consultation à ouvrir (double-clic), ou null.</summary>
        public int? ConsultationChoisie { get; private set; }

        /// <summary>Vrai si l'utilisateur a cliqué sur « Nouvelle consultation ».</summary>
        public bool NouvelleDemandee { get; private set; }

        private void HistoriquePatient_Load(object sender, EventArgs e)
        {
            if (Db.EnModeConception)
            {
                return;
            }

            Db.TryRun(delegate
            {
                DataTable table = Db.Query(
                    "SELECT c.id_CONSULTATION AS Id, c.date_cons AS [Date], m.nom_med AS [Médecin], c.prix_cons AS Prix " +
                    "FROM CONSULTATION c JOIN MEDECIN m ON m.id_MEDECIN = c.id_MEDECIN " +
                    "WHERE c.id_PATIENT = @id ORDER BY c.date_cons DESC",
                    Db.P("@id", idPatient));

                // Statut calculé à partir de la date
                table.Columns.Add("Statut", typeof(string));
                DateTime? derniere = null;
                DateTime? prochaine = null;
                decimal montant = 0;
                foreach (DataRow r in table.Rows)
                {
                    DateTime d = Convert.ToDateTime(r["Date"]);
                    montant += Convert.ToDecimal(r["Prix"]);
                    if (d.Date == DateTime.Today)
                    {
                        r["Statut"] = "Aujourd'hui";
                    }
                    else if (d > DateTime.Now)
                    {
                        r["Statut"] = "À venir";
                    }
                    else
                    {
                        r["Statut"] = "Passée";
                    }

                    if (d <= DateTime.Now && (derniere == null || d > derniere)) derniere = d;
                    if (d > DateTime.Now && (prochaine == null || d < prochaine)) prochaine = d;
                }

                grid.DataSource = table;
                grid.Columns["Id"].Visible = false;
                grid.Columns["Date"].DefaultCellStyle.Format = "dddd d MMMM yyyy  ·  HH:mm";
                grid.Columns["Prix"].DefaultCellStyle.Format = "N2";
                grid.Columns["Date"].FillWeight = 200;
                grid.Columns["Prix"].FillWeight = 70;
                grid.Columns["Statut"].FillWeight = 80;

                statTotal.Valeur = table.Rows.Count.ToString();
                statDerniere.Valeur = derniere.HasValue ? derniere.Value.ToString("dd/MM/yyyy") : "—";
                statProchaine.Valeur = prochaine.HasValue ? prochaine.Value.ToString("dd/MM · HH:mm") : "Aucun";
                statMontant.Valeur = montant.ToString("N2");
                lblListe.Text = "Historique des consultations (" + table.Rows.Count + ")";
            });
        }

        /// <summary>Couleur du statut : bleu = à venir, orange = aujourd'hui, gris = passée.</summary>
        private void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || grid.Columns[e.ColumnIndex].Name != "Statut")
            {
                return;
            }
            string statut = Convert.ToString(e.Value);
            e.CellStyle.Font = Theme.Semibold(9.5F);
            e.CellStyle.ForeColor = statut == "À venir" ? Theme.Primary
                                  : statut == "Aujourd'hui" ? Theme.Warning
                                  : Theme.TextMuted;
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            ConsultationChoisie = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["Id"].Value);
            DialogResult = DialogResult.OK;
        }

        private void btnNouvelle_Click(object sender, EventArgs e)
        {
            NouvelleDemandee = true;
            DialogResult = DialogResult.OK;
        }
    }
}
