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
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages
{
    public partial class Zanrid : PageUserControl
    {
        AdminDefaultManagerPage<Zanr> Page { get; set; }
        public Zanrid(): base()
        {
            
        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Zanr>("zanr");
            this.Controls.Add(Page);
        }
    }
}

