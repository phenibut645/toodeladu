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
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages
{
    public partial class Skeem : PageUserControl
    {
        AdminDefaultManagerPage<zxcforum.core.models.database.Skeem> Page { get; set; }
        public Skeem() : base()
        {

        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<core.models.database.Skeem>("nimi");
            this.Controls.Add(Page);
        }
    }
}
