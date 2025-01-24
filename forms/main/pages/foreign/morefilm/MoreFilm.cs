using zxcforum.core.controls;
using zxcforum.core.models.database;
using zxcforum.core.presets;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms.main.pages
{
    public partial class MoreFilm : PageUserControl
    {
        public MoreFilm(Film film): base()
        {
            Film = film;
        }
    }
}
