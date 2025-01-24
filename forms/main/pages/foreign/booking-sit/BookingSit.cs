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
using zxcforum.core.models;
using zxcforum.core.models.database;

namespace zxcforum.forms.main.pages.foreign
{
    public partial class BookingSit : PageUserControl
    {
        public Seans Film { get; set; }
        public BookingSit(Seans seans): base()
        {
            Seanss = seans;
        }
    }
}
