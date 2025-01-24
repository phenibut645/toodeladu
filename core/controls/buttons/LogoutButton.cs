using zxcforum.core.context;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace zxcforum.core.controls.buttons
{
    public partial class LogoutButton: Button
    {
        public LogoutButton(int x, int y, int fontsize)
        {
            this.Text = "Logout";
            this.BackColor = ColorManagment.InputColors;
            this.ForeColor = Color.White;
            this.Font = DefaultFonts.GetFont(fontsize);
            this.Size = new Size(x, y);
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Click += LogoutButton_Click;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            FormAppContext.MainForm.Logout();
        }
    }
}
