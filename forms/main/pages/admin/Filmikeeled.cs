using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.controls;
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages
{
    public class Filmikeeled : PageUserControl
    {
        AdminDefaultManagerPage<Film> Page { get; set; }
        public Filmikeeled() : base()
        {

        }
        public override void InitAll()
        {
            base.InitAll();
            Page = new AdminDefaultManagerPage<Film>("keel");
            this.Controls.Add(Page);
        }
    }
}
