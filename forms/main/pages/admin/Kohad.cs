using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.controls;
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages
{
    public class Kohad : PageUserControl
    {
        AdminDefaultManagerPage<Koht> Page { get; set; }
        public Kohad() : base()
        {

        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Koht>("id");
            this.Controls.Add(Page);
        }
    }
}
