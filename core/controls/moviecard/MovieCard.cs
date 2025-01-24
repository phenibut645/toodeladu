using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public partial class MovieCard : UserControl
    {
        public MovieCard(Film film)
        {
            FilmTable = film;
            this.BackColor = ColorManagment.MoveCardBackground;
            this.Size = new Size(SizeX, SizeY);

            InitAll();
        }
    }
}
