using zxcforum.core.controls;
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
using zxcforum.core.enums;
using System.Runtime.InteropServices;
using zxcforum.core.utils;
using zxcforum.core.context;
using zxcforum.core.controls.buttons;
using zxcforum.core.models.database;
namespace zxcforum.forms.main.pages
{
    public partial class Profile : PageUserControl
    {
        public AvatarChangeAbility ACA;
        public Option<Kasutaja> VanusOption { get; set; }
        public Option<Kasutaja> RollOption { get; set; }
        public Option<Kasutaja> SalaSonaOption { get; set; }
        public Label UserName { get; set; }
        public Panel MainContainer { get; set; }
        public LogoutButton Logout { get; set; }
        public Profile(): base()
        {
            this.Size = new Size(1720, 903);
        }
        public override void InitAll()
        {
            base.InitAll();
            MainContainer = new Panel();
            this.Controls.Add(MainContainer);
            MainContainer.Size = new Size(757, 782);
            MainContainer.Location = new Point(480, 31);

            ACA = new AvatarChangeAbility(FormAppContext.CurrentUser);
            MainContainer.Controls.Add(ACA);
            ACA.Location = new Point(315, 60);

            Kasutaja kasutaja = DBHandler.GetRecord<Kasutaja>(new List<WhereField>() { new WhereField("id", FormAppContext.CurrentUser.id.ToString()) });
            VanusOption = new Option<Kasutaja>(kasutaja, "vanus", OptionType.Number, "Vanus");
            VanusOption.Button.Available = true;
            MainContainer.Controls.Add(VanusOption);
            VanusOption.Location = new Point(196, 296);

            RollOption = new Option<Kasutaja>(kasutaja, "roll", OptionType.Default, "Roll");
            MainContainer.Controls.Add(RollOption);
            RollOption.Location = new Point(196, 379);

            SalaSonaOption = new Option<Kasutaja>(kasutaja, "salasona", OptionType.Default, "Salasõna");
            SalaSonaOption.Button.Available = true;
            MainContainer.Controls.Add(SalaSonaOption);
            SalaSonaOption.Location = new Point(196, 462);

            UserName = new Label();
            UserName.Text = FormAppContext.CurrentUser.name;
            UserName.ForeColor = Color.White;
            UserName.Size = new Size(500, 60);
            UserName.TextAlign = ContentAlignment.MiddleCenter;
            UserName.Location = new Point(MainContainer.Width / 2 - UserName.Width / 2, 195);
            MainContainer.Controls.Add(UserName);
            UserName.Font = core.utils.DefaultFonts.GetFont(34);

            Logout = new LogoutButton(348, 77, 22);
            Logout.Location = new Point(MainContainer.Width / 2 - Logout.Width / 2, 589);
            MainContainer.Controls.Add(Logout);
        }
    }
}
