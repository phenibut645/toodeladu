using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum
{
    public partial class Login : Form
    {
        public Login()
        {
            this.Text = "Login";
            this.ClientSize = new Size(Width, Height);
            this.InitLogin();
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.BackColor = ColorManagment.BackGroundColor;
        }
    }
}
