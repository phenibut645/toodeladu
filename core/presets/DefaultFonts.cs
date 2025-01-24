using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace zxcforum.core.utils
{
    public static class DefaultFonts
    {
        public static PrivateFontCollection jaroRegualr;
        public static PrivateFontCollection kanitRegular;

        static DefaultFonts()
        {
            PrivateFontCollection font = new PrivateFontCollection();
            font.AddFontFile(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\fonts\jaro\Jaro-Regular.ttf")));
            jaroRegualr = font;
            font = new PrivateFontCollection();
            font.AddFontFile(Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\other\fonts\jaro\Kanit-Regular.ttf")));
            kanitRegular = font;
        }

        public static Font GetFont(int size)
        {
            return new Font(jaroRegualr.Families[0], size);
        }
        public static Font GetKanitFont(int size)
        {
            return new Font(kanitRegular.Families[0], size);
        }
    }
}
