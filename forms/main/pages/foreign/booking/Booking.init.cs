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
namespace zxcforum.forms.main.pages.foreign
{
    public partial class Booking : PageUserControl
    {
        public override void InitAll()
        {
            base.InitAll();
            //InitLines();
            seansid = DBHandler.GetTableData<Seans>();
            int y = 50;
            foreach(Seans seans in seansid)
            {
                Console.WriteLine("GENM");
                if (seans["film"] == this.Film["id"])
                {
                    Console.WriteLine("GENM123");
                    Panel panel = new Panel();
                    Label time = new Label();
                    Label keel = new Label();
                    Label saalinimetus = new Label();
                    time.Font = DefaultFonts.GetKanitFont(15);
                    keel.Font = DefaultFonts.GetKanitFont(15);
                    saalinimetus.Font = DefaultFonts.GetKanitFont(15);
                    time.Text = $"aeg: {seans["aeg"]}, kuupäev:{seans["kuupaev"]}";
                    Console.WriteLine($"{seans["aeg"]} | {seans["kuupaev"]}");
                    Console.WriteLine(seans["filmikeel"]);
                    Console.WriteLine(DBHandler.GetRecord<Saal>(new List<WhereField> { new WhereField("id", seans["saal"]) })["nimetus"]);
                    time.AutoSize = true;
                    keel.AutoSize = true;
                    saalinimetus.AutoSize = true;
                    keel.Text = $"keel: {DBHandler.GetRecord<Filmikeel>(new List<WhereField> { new WhereField("id", seans["filmikeel"]) })["keel"]}";
                    
                    saalinimetus.Text = $"saali nimetus: {DBHandler.GetRecord<Saal>(new List<WhereField> { new WhereField("id", seans["saal"]) })["nimetus"]}";
                    panel.ClientSize = new Size(900, 100);

                    panel.Controls.Add(time);
                  
                    panel.Controls.Add(keel);
                    panel.Controls.Add(saalinimetus);
                    time.ForeColor = Color.White;
                    keel.ForeColor = Color.White;
                    saalinimetus.ForeColor = Color.White;



                    time.Location = new Point(50, panel.Height / 2 - time.Height / 2);
                    keel.Location = new Point(time.Width + 50, panel.Height / 2 -  keel.Height / 2);
                    saalinimetus.Location = new Point(keel.Location.X + keel.Width + 50, panel.Height / 2 - saalinimetus.Height / 2);
                    panel.BackColor = ColorManagment.DefaultPanelColor;
                    panel.Click += Panel_Click;
                    panel.Tag = seans;
                    this.Controls.Add(panel);
                    panel.Location = new Point(this.Width / 2 - panel.Width / 2 , y);
                    y += panel.Height + 50;
                }
            }
        }

        private void Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if(panel != null)
            {
                Seans seans = panel.Tag as Seans;
                if (seans != null)
                {
                    HeaderHandler.ChangeToForeignPage(new BookingSit(seans));
                }
            }
            
        }
    }
}
