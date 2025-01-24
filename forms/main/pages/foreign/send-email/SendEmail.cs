using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.context;
using zxcforum.core.controls;
using zxcforum.core.models;
using zxcforum.core.models.database;
using zxcforum.core.utils;

namespace zxcforum.forms.main.pages.foreign.send_email
{
    public partial class SendEmail : PageUserControl
    {
        public core.models.database.BroneeritudKoht Koht { get; set; }
        public TextBox EmailBox { get; set; }
        public SendEmail(core.models.database.BroneeritudKoht koht)
        {
            Koht = koht;
        }
        public override void InitAll()
        {
            base.InitAll();
            Button button = new Button();
            button.Text = "Submit";
            button.Font = DefaultFonts.GetKanitFont(16);
            button.ForeColor = Color.White;
            button.BackColor = ColorManagment.InputColors;
            button.Click += Button_Click;
            Label label = new Label();
            label.Text = "Email";
            label.Font = DefaultFonts.GetKanitFont(13);
            label.ForeColor = Color.White;

            EmailBox = new TextBox();
            EmailBox.Font = DefaultFonts.GetKanitFont(15);
            this.Controls.Add(button);
            this.Controls.Add(label);
            this.Controls.Add(EmailBox);
            EmailBox.Size = new Size(250, 200);
            button.Size = new Size(250, 100);
            label.Location = new Point(50, 50);
            EmailBox.Location = new Point(50, label.Height + 50);

            button.Location = new Point(50, label.Height + 50 + EmailBox.Height + 50 + 80);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Seans seans = DBHandler.GetRecord<Seans>(new List<core.models.WhereField>() { new core.models.WhereField("id", Koht["seanss"])});
            Film film = DBHandler.GetRecord<Film>(new List<core.models.WhereField>() { new core.models.WhereField("id", seans["film"])});
            Koht koht = DBHandler.GetRecord<Koht>(new List<core.models.WhereField>() { new core.models.WhereField("id", Koht["koht"])});
            TicketsHandler.SendEmail(film, FormAppContext.CurrentUser, koht["coord_x"], koht["coord_y"], EmailBox.Text);
        }
    }
}
