using zxcforum.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms.main.pages
{
    public partial class Kava
    {
        public Panel MainPanel { get; set; }
        public List<MovieCard> MovieCards { get; set; } = new List<MovieCard>();
        public int StartCardX { get; set; } = 52;
        public int StartCardY { get; set; } = 52;
        public int BetweenCardsGapX { get; set; } = 42;
        public int BetweenCardsGapY { get; set; } = 42;
    }
}
