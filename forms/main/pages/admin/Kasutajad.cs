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

namespace zxcforum.forms.main.pages
{
    public partial class Kasutajad : PageUserControl
    {
        AdminDefaultManagerPage<Kasutaja> Page { get; set; }
        public Kasutajad(): base()
        {
            
        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Kasutaja>("nimi");
            this.Controls.Add(Page);
        }
    }
}
