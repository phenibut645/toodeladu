using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class MovieCard
    {
        public int SizeX { get; set; } = 787;
        public int SizeY { get; set; } = 406;
        public List<List<int>> LinesWidth = new List<List<int>>()
        { 
            new List<int>(){787, 6 } , new List<int>(){6, 406}, new List<int>(){787, 6}, new List<int>(){6, 406}, new List<int>(){6, 406}
        };
        public string PostersPath { get; set; } = DefaultPaths.PostersPath;
        public int LineThickness { get; set; } = 6;

        // Components
        public PictureBox Poster { get; set; }
        public Label Header { get; set; }
        public Film FilmTable { get; set; }
        public Label RunTimeLabel { get; set; }
        public Label RunTime { get; set; }
        public Label GenreLabel { get; set;}
        public Label Genre { get; set; }
        public Button ButtonMore { get; set; }

    }
}
