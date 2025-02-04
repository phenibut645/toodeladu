using zxcforum.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms.main.pages
{
    public partial class Shop
    {
        public Panel MainPanel { get; set; }
        public int StartCardX { get; set; } = 52;
        public int StartCardY { get; set; } = 52;
        public int BetweenCardsGapX { get; set; } = 42;
        public int BetweenCardsGapY { get; set; } = 42;
    }
}
