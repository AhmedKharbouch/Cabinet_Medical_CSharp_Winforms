using System.Data;

namespace TEST
{
    /// <summary>Informations sur l'utilisateur connecté.</summary>
    internal static class Session
    {
        public static string NomMedecin { get; set; }

        /// <summary>Vue choisie pour les consultations du tableau de bord (calendrier ou liste).</summary>
        public static bool DashboardEnCalendrier { get; set; }
    }

    /// <summary>Petites aides partagées par les pages.</summary>
    internal static class Ui
    {
        /// <summary>
        /// Filtre un tableau lié à une DataTable : garde les lignes dont une des colonnes
        /// indiquées contient le texte recherché.
        /// </summary>
        public static void Filtrer(object source, string recherche, params string[] colonnes)
        {
            DataTable table = source as DataTable;
            if (table == null)
            {
                return;
            }

            string texte = (recherche ?? "").Trim();
            if (texte.Length == 0)
            {
                table.DefaultView.RowFilter = "";
                return;
            }

            // Échappe les caractères spéciaux de la syntaxe RowFilter.
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (char c in texte)
            {
                if (c == '[' || c == ']' || c == '*' || c == '%') sb.Append('[').Append(c).Append(']');
                else if (c == '\'') sb.Append("''");
                else sb.Append(c);
            }
            string echappe = sb.ToString();
            string filtre = "";
            foreach (string colonne in colonnes)
            {
                if (filtre.Length > 0)
                {
                    filtre += " OR ";
                }
                filtre += "CONVERT([" + colonne + "], 'System.String') LIKE '%" + echappe + "%'";
            }
            table.DefaultView.RowFilter = filtre;
        }

        public static string Pluriel(int n, string singulier, string pluriel)
        {
            return n + " " + (n > 1 ? pluriel : singulier);
        }
    }
}
