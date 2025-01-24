using zxcforum.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.utils;
using zxcforum.core.context;
using zxcforum.core.models.database;
using System.Drawing;
using zxcforum.forms.main.pages;

namespace zxcforum.forms.main
{
    public partial class Menu
    {
        public void RefreshForm()
        {
            HeaderHandler.ClearEverything();
            MainPage = null;
            InitAll();
        }
        public void Logout()
        {
           FormAppContext.CurrentUser = null;
        }
    }
}
