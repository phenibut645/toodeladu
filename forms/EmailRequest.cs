using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zxcforum.forms
{
    public class EmailRequest: Form
    {
        public TextBox EmailTextBox { get; set; }
        public Button SubmitButton { get; set; }

        public string CurrentEmail
        { 
            get 
            {
               return EmailTextBox.Text;
            }
        }

        public EmailRequest()
        {
            this.BackColor = ColorManagment.BackGroundColor;
            this.Text = "Email";
            this.ClientSize = new System.Drawing.Size(500, 500);


            this.InitAll();
        }
        public void InitAll()
        {
            EmailTextBox = new TextBox();
            EmailTextBox.Font = DefaultFonts.GetKanitFont(18);
            EmailTextBox.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(EmailTextBox);
            EmailTextBox.Location = new System.Drawing.Point(this.ClientSize.Width / 2 - EmailTextBox.Width / 2, this.ClientSize.Height / 2 - EmailTextBox.Height / 2);


            SubmitButton = new Button();
            SubmitButton.ClientSize = new System.Drawing.Size(100, 50);
            this.Controls.Add(SubmitButton);
        }
    }
}
