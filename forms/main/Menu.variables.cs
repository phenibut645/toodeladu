using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using zxcforum.core.enums;
using zxcforum.core.controls;
using System.IO;
using zxcforum.core.models;

namespace zxcforum.forms.main
{
    public partial class Menu
    {
        public Panel Header { get; set; }
        public Label HeaderLine { get; set; }
        public HeaderButton ActiveButton { get; set; }
        public PageUserControl MainPage { get; set; }
        
    }
}