using zxcforum.core.context;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.utils;
using zxcforum.forms.main.pages;

namespace zxcforum.core.controls
{
    public partial class MovieCard
    {
        public void buttonMore_clicked(object sedner, EventArgs e)
        {
            HeaderHandler.ChangeToForeignPage(new MoreFilm(this.FilmTable));
        }
    }
}
