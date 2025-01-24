using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.controls;
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages
{
    public class SaaliTuup : PageUserControl
    {
        AdminDefaultManagerPage<Saalituup> Page { get; set; }
        public SaaliTuup() : base()
        {

        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Saalituup>("tuup");
            this.Controls.Add(Page);
        }
    }
}
