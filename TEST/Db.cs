using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TEST
{
    /// <summary>
    /// Accès centralisé à la base gestion_hopital.
    /// Chaque appel ouvre et ferme sa propre connexion (bloc using),
    /// et toutes les valeurs passent par des paramètres SQL.
    /// </summary>
    internal static class Db
    {
        private const string NomConnexion = "gestion_hopital";
        private const string ConnexionParDefaut = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=gestion_hopital;Integrated Security=True";

        public static string ConnectionString
        {
            get
            {
                ConnectionStringSettings cs = ConfigurationManager.ConnectionStrings[NomConnexion];
                return cs != null ? cs.ConnectionString : ConnexionParDefaut;
            }
        }

        /// <summary>Vrai quand le code tourne dans le concepteur de Visual Studio.</summary>
        public static bool EnModeConception
        {
            get { return LicenseManager.UsageMode == LicenseUsageMode.Designtime; }
        }

        public static SqlParameter P(string nom, object valeur)
        {
            return new SqlParameter(nom, valeur ?? DBNull.Value);
        }

        public static DataTable Query(string sql, params SqlParameter[] parametres)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddRange(parametres);
                DataTable table = new DataTable();
                da.Fill(table);
                return table;
            }
        }

        public static int Execute(string sql, params SqlParameter[] parametres)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parametres);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public static object Scalar(string sql, params SqlParameter[] parametres)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parametres);
                con.Open();
                object resultat = cmd.ExecuteScalar();
                return resultat == DBNull.Value ? null : resultat;
            }
        }

        public static int Count(string sql, params SqlParameter[] parametres)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddRange(parametres);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        /// <summary>
        /// Exécute une action sur la base et affiche un message clair en cas d'erreur
        /// au lieu de faire planter l'application. Renvoie false si l'action a échoué.
        /// </summary>
        public static bool TryRun(Action action)
        {
            try
            {
                action();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erreur de base de données :\n" + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Erreur :\n" + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool Confirmer(string message)
        {
            return MessageBox.Show(message, "Confirmation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        public static void Info(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Alerte(string message)
        {
            MessageBox.Show(message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>Lit une cellule sans planter si elle est vide (null ou DBNull).</summary>
        public static string Cellule(DataGridViewRow ligne, int index)
        {
            return Convert.ToString(ligne.Cells[index].Value);
        }

        /// <summary>N'accepte que les chiffres (et les touches de contrôle comme Retour arrière).</summary>
        public static void ChiffresSeulement(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
