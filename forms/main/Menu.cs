using zxcforum.core.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.models;
using zxcforum.core.utils;
using zxcforum.core.context;
using System.IO;
namespace zxcforum.forms.main
{
    public partial class Menu : Form
    {
        public Menu()
        {
            this.Icon = new Icon(Path.Combine(DefaultPaths.DefaultImagesPath, "icon.ico"));
            this.Text = "CookieKino";
            this.BackColor = ColorManagment.BackGroundColor;
            this.ClientSize = new Size(1720, 980);

            FormAppContext.MainForm = this;
            FormAppContext.LoggedIn += LoggedIn;
            InitAll();
        }
    }
}
