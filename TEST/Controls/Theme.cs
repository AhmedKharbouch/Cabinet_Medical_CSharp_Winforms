using System.Collections.Generic;
using System.Drawing;

namespace TEST.Controls
{
    /// <summary>Palette de couleurs et polices partagées par tous les écrans.</summary>
    public static class Theme
    {
        // Couleur principale (bleu)
        public static readonly Color Primary = Color.FromArgb(37, 99, 235);
        public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
        public static readonly Color PrimaryPressed = Color.FromArgb(30, 64, 175);
        public static readonly Color PrimarySoft = Color.FromArgb(219, 234, 254);

        // États
        public static readonly Color Danger = Color.FromArgb(220, 38, 38);
        public static readonly Color DangerBorder = Color.FromArgb(252, 165, 165);
        public static readonly Color DangerSoft = Color.FromArgb(254, 226, 226);
        public static readonly Color Success = Color.FromArgb(21, 128, 61);
        public static readonly Color SuccessSoft = Color.FromArgb(220, 252, 231);
        public static readonly Color Warning = Color.FromArgb(217, 119, 6);
        public static readonly Color WarningSoft = Color.FromArgb(254, 243, 199);
        public static readonly Color Violet = Color.FromArgb(124, 58, 237);
        public static readonly Color VioletSoft = Color.FromArgb(237, 233, 254);

        // Surfaces et texte
        public static readonly Color Background = Color.FromArgb(241, 245, 249);
        public static readonly Color Surface = Color.White;
        public static readonly Color SurfaceHover = Color.FromArgb(248, 250, 252);
        public static readonly Color Border = Color.FromArgb(226, 232, 240);
        public static readonly Color BorderStrong = Color.FromArgb(203, 213, 225);
        public static readonly Color Text = Color.FromArgb(15, 23, 42);
        public static readonly Color TextMuted = Color.FromArgb(100, 116, 139);
        public static readonly Color TextDisabled = Color.FromArgb(148, 163, 184);

        // Menu latéral
        public static readonly Color Sidebar = Color.FromArgb(15, 23, 42);
        public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);
        public static readonly Color SidebarText = Color.FromArgb(203, 213, 225);

        public const string FontFamily = "Segoe UI";
        public const string IconFamily = "Segoe MDL2 Assets";

        private static readonly Dictionary<string, Font> cache = new Dictionary<string, Font>();

        public static Font Font(float taille, FontStyle style = FontStyle.Regular)
        {
            return Get(FontFamily, taille, style);
        }

        public static Font Semibold(float taille)
        {
            return Get("Segoe UI Semibold", taille, FontStyle.Regular);
        }

        public static Font Icon(float taille)
        {
            return Get(IconFamily, taille, FontStyle.Regular);
        }

        private static Font Get(string famille, float taille, FontStyle style)
        {
            string cle = famille + "|" + taille + "|" + style;
            Font f;
            if (!cache.TryGetValue(cle, out f))
            {
                f = new Font(famille, taille, style);
                cache[cle] = f;
            }
            return f;
        }
    }

    /// <summary>Codes des icônes de la police Segoe MDL2 Assets (fournie avec Windows 10/11).</summary>
    public static class Glyphs
    {
        public const string Home = "";
        public const string People = "";
        public const string Doctor = "";
        public const string Health = "";
        public const string Calendar = "";
        public const string SignOut = "";
        public const string Search = "";
        public const string Add = "";
        public const string Save = "";
        public const string Delete = "";
        public const string Clear = "";
        public const string Money = "";
        public const string Clock = "";
        public const string Contact = "";
    }
}
