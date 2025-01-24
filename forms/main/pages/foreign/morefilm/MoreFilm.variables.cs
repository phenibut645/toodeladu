using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms.main.pages
{
    public partial class MoreFilm
    {
        public PictureBox Poster { get; set; }
        public Label FilmName { get; set; }
        public Label GenreLabel { get; set; }
        public Label GenreLabelValue { get; set; }
        public Label RunTimeLabel { get; set; }
        public Label RunTimeLabelValue { get; set; }
        public Label KirjeldusLabel { get; set; }
        public Label KirjeldusLabelValue { get; set; }
        public Label SeansidLabel { get; set; }
        public Button CloseButton { get; set; }
        public Button OstaPiletButton { get; set; }
        public Film Film { get; set; }

        public List<List<int>> LinesWidth = new List<List<int>>()
        { 
            new List<int>(){863, 6 } , new List<int>(){6, 952}, new List<int>(){863, 6}, new List<int>(){6, 952}, new List<int>(){6, 406}, new List<int>(){277, 6}
        };
        public int LineThickness { get; set; } = 6;
    }
}
