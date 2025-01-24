using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum
{
    public partial class Login
    {
        public int Width { get; private set; } = 800;
        public int Height { get; private set; } = 800;

        public TextBox UserName { get; private set; }
        public TextBox Password { get; private set; }
        public TextBox ConfirmPassword { get; private set; }
        public Label UserNameLabel { get; private set; }
        public Label PasswordLabel { get; private set; }
        public Label ConfirmPasswordLabel { get; private set; }
        public Button SubmitButton { get; private set; }
        public Label SignInLabel { get; private set; }
        //public Font MaintFont { get; private set; } =new Font("Arial", 19);
        public Font MaintFont { get; private set; } = DefaultFonts.GetFont(19);
        
    }
}
