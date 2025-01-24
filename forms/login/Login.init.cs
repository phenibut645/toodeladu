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
using zxcforum.core.utils;

namespace zxcforum
{
    public partial class Login
    {
        private void InitLogin()
        {
            InitLabels();
            InitTextBoxes();
            InitSubmitButton();
            InitSignInLabel();
        }
        private void InitSignin()
        {
            InitLabels(false);
            InitTextBoxes(false);
            InitSubmitButton(false);
        }
        private void InitLabels(bool Login = true)
        {
            this.UserNameLabel = new Label();
            UserNameLabel.ClientSize = new Size(204, 47);
            UserNameLabel.Font = MaintFont;

            UserNameLabel.Text = "Username";
            UserNameLabel.ForeColor = Color.White;
            

            this.PasswordLabel = new Label();
            PasswordLabel.ClientSize = new Size(1655, 39);
            PasswordLabel.Font = MaintFont;

            PasswordLabel.Text = "Password";
            PasswordLabel.ForeColor = Color.White;

            if (!Login)
            {
                this.ConfirmPasswordLabel = new Label();
                ConfirmPasswordLabel.ClientSize = new Size(1655, 39);
                ConfirmPasswordLabel.Font = MaintFont;
                ConfirmPasswordLabel.Location = new Point(258, 376);
                ConfirmPasswordLabel.Text = "Confirm the password";
                ConfirmPasswordLabel.ForeColor = Color.White;

                UserNameLabel.Location = new Point(258, 133);
                PasswordLabel.Location = new Point(258, 255);

                this.Controls.Add(ConfirmPasswordLabel);
            }
            else
            {
                UserNameLabel.Location = new Point(258, 199);
                PasswordLabel.Location = new Point(258, 368);
            }

            this.Controls.Add(UserNameLabel);
            this.Controls.Add(PasswordLabel);

        }
        private void InitTextBoxes(bool Login = true)
        {
            this.UserName = new TextBox();
            UserName.Name = "username_textbox";
            UserName.Font = new Font("Arial", 16);
            UserName.ClientSize = new Size(283, 46);

            UserName.BorderStyle = BorderStyle.None;
            UserName.BackColor = ColorManagment.InputColors;
            UserName.ForeColor = Color.White;
            this.Controls.Add(UserName);

            Password = new TextBox();
            Password.Name = "password_textbox";
            Password.Font = new Font("Arial", 16);
            Password.ClientSize = new Size(283, 46);
            Password.BorderStyle = BorderStyle.None;

            Password.ForeColor = Color.White;
            Password.BackColor = ColorManagment.InputColors;

            if (!Login)
            {
                this.ConfirmPassword = new TextBox();
                ConfirmPassword.ClientSize = new Size(283, 46);
                ConfirmPassword.Font = new Font("Arial", 16);
                ConfirmPassword.Location = new Point(258, 433);
                ConfirmPassword.ForeColor = Color.White;
                ConfirmPassword.BackColor = ColorManagment.InputColors;
                ConfirmPassword.BorderStyle = BorderStyle.None;
                UserName.Location = new Point(258, 191);
                Password.Location = new Point(258, 312);
                this.Controls.Add(ConfirmPassword);
            }
            else
            {
                UserName.Location = new Point(258, 264);
                Password.Location = new Point(258, 425);
                Password.PasswordChar = '*';
            }

            this.Controls.Add(Password);
        }
        private void InitSubmitButton(bool Login = true)
        {
            SubmitButton = new Button();
            SubmitButton.Name = "submit_button";
            SubmitButton.ClientSize = new Size(204, 69);
            SubmitButton.Font = MaintFont;

            SubmitButton.Text = "Submit";
            SubmitButton.BackColor = ColorManagment.InputColors;
            SubmitButton.ForeColor = Color.White;
            SubmitButton.FlatStyle = FlatStyle.Flat;
            SubmitButton.FlatAppearance.BorderSize = 0;
            
            Controls.Add(SubmitButton);
            if(Login)
            {
                SubmitButton.Location = new Point(298, 532);
                SubmitButton.Click += this.submitButton_click;
            }
            else
            {
                SubmitButton.Location = new Point(298, 561);
                SubmitButton.Click += this.submitSignInButton_click;
            }
        }
        private void InitSignInLabel()
        {
            SignInLabel = new Label();
            SignInLabel.Text = "Create a new account";
            SignInLabel.Font = DefaultFonts.GetFont(13);
            SignInLabel.BackColor = ColorManagment.InvisibleBackGround;
            SignInLabel.ForeColor = Color.White;
            SignInLabel.Click += SignIn;
            SignInLabel.AutoSize = true;
            SignInLabel.Size = new Size(138, 20);
            SignInLabel.Location = new Point(this.Width / 2 - SignInLabel.Width / 2, 619);
            this.Controls.Add(SignInLabel);
        }


    }
}
