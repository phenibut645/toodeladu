using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.controls;
using zxcforum.core.utils;
using zxcforum.core.models;
using zxcforum.core.models.database;
using System.Runtime.InteropServices;
using zxcforum.core.context;
using zxcforum.forms.main.pages.foreign.send_email;
namespace zxcforum.forms.main.pages.foreign
{
    public partial class BookingSit : PageUserControl
    {
        public override void InitAll()
        {
            base.InitAll();
            //InitLines();
            Saal saal = DBHandler.GetRecord<Saal>(new List<WhereField> { new WhereField("id", Seanss["saal"])});
            core.models.database.Skeem skeem = DBHandler.GetRecord<core.models.database.Skeem>(new List<WhereField> { new WhereField("id", saal["skeem"])});
            int x = 50;
            int y = 50;
            int coord_x = 0;
            int coord_y = 0;
            for(int i = 0; i < int.Parse(skeem["veerg_arv"]); i++)
            {
                coord_y += 1;
                for (int j = 0; j < int.Parse(skeem["riida_arv"]); j++)
                {
                    coord_x += 1;
                    Panel panel = new Panel();
                    panel.ClientSize = new Size(80, 80);
                    core.models.database.Koht koht = DBHandler.GetRecord<core.models.database.Koht>(new List<WhereField> { new WhereField("coord_x", coord_x.ToString()), new WhereField("coord_y", coord_y.ToString())});
                    if (koht["id"] == null)
                    {
                        koht["coord_x"] = coord_x.ToString();
                        koht["coord_y"] = coord_y.ToString();
                        koht["kohatuup"] = "1";
                        koht["skeem"] = skeem["id"];
                        DBHandler.AddRecord<Koht>(koht);
                    }
                    else
                    {
                        core.models.database.BroneeritudKoht brkoht = DBHandler.GetRecord<core.models.database.BroneeritudKoht>(new List<WhereField> { new WhereField("koht", koht["id"])});
                        if (brkoht["id"] != null)
                        {
                            panel.BackColor = Color.Red;
                        }
                        else
                        {
                            panel.BackColor = ColorManagment.InputColors;
                            panel.Click += Panel_Click1;
                            panel.Tag = koht;
                        }
                    }
                    
                    this.Controls.Add(panel);
                    panel.Location = new Point(x, y);
                    y += panel.Height + 20;
                }
                y = 50;
                x += 80 + 20;
            }
        }

        private void Panel_Click1(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if(panel != null)
            {
                Koht koht = panel.Tag as Koht;
                if(koht != null)
                {
                    core.models.database.BroneeritudKoht brkoht = new core.models.database.BroneeritudKoht();
                    brkoht["koht"] = koht["id"];
                    brkoht["kasutaja"] = FormAppContext.CurrentUser.id.ToString();
                    brkoht["seanss"] = this.Seanss["id"];
                    DBHandler.AddRecord< core.models.database.BroneeritudKoht>(brkoht);
                    HeaderHandler.ChangeToForeignPage(new SendEmail(brkoht));
                }
            }
        }
    }
}
