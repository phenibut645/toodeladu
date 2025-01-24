using zxcforum.core.controls;
using zxcforum.core.models.database;
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

namespace zxcforum.forms.main.pages
{
    public partial class Seansid : PageUserControl
    {
        AdminDefaultManagerPage<Seans> Page { get; set; }
        public Seansid(): base()
        {
            
        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Seans>("aeg");
            this.Controls.Add(Page);
        }
    }
}
