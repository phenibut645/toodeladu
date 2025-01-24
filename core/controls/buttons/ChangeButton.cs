using zxcforum.core.enums;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace zxcforum.core.controls
{
    public class ChangeButton: Panel
    {
        public PictureBox Button { get; set; }
        public OptionType Type { get; set; }
        private bool _abailable = false;
        private bool _inChange = false;
        public bool InChange 
        {
            get
            { 
                return _inChange;
            }
            set
            {
                _inChange = value;
                if (_inChange) this.Button.BackgroundImage = DefaultImages.GetDefaultImage("check.png");
                else this.Button.BackgroundImage = DefaultImages.GetDefaultImage("pencil.png");
            } 
        }
        public bool Available
        {
            get
            {
                return _abailable;
            }
            set
            {
                if (value) Button.BackgroundImage = DefaultImages.GetDefaultImage("pencil.png");
                else Button.BackgroundImage = DefaultImages.GetDefaultImage("denied.png");
                _abailable = value;
                Button.Enabled = value;
            }
        }
        public ChangeButton(OptionType type, int sizeX = 49, int sizeY = 49)
        {
            Type = type;
            Button = new PictureBox();
            Available = false;
            this.BackColor = ColorManagment.OptionField;

            this.ClientSize = new System.Drawing.Size(49, 49);
            Button.ClientSize = new System.Drawing.Size(32, 32);
            Button.BackColor = ColorManagment.InvisibleBackGround;
            Button.BackgroundImageLayout = ImageLayout.Zoom;
            Button.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - Button.ClientSize.Width / 2, this.ClientSize.Height / 2 - Button.ClientSize.Height / 2);

            this.Controls.Add(Button);
        }
        public void AddClick(EventHandler e)
        {
            Button.Click += e;
            this.Click += e;
        }
    }
}
