using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.context;
using zxcforum.core.models;
using zxcforum.core.models.database;
using zxcforum.core.utils;
namespace zxcforum.core.controls
{
    public partial class AvatarChangeAbility : UserControl
    {
        public PictureBox Avatar { get; private set; }
        public Panel ButtonContainer { get; private set; } = new Panel();
        public Button ChangeButton { get; private set; }
        public User User { get; private set; }
        public AvatarChangeAbility(User user)
        {
            this.Size = new Size(121, 121);
            this.User = user;
            InitAll();
        }
        private void InitAll()
        {
            InitButtonContainer();
            InitButton();
            InitAvatar();
        }
        private void InitAvatar()
        {
            Avatar = new PictureBox();
            Avatar.Size = new Size(121, 121);
            Avatar.Location = new Point(0, 0);
            Avatar.BackColor = Color.Yellow;
            Avatar.Image = DefaultImages.GetAvatar(User);
            Avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            Avatar.BackColor = ColorManagment.InvisibleBackGround;
            this.Controls.Add(Avatar);
            
        }
        private void InitButton()
        {
            ChangeButton = new Button();
            ChangeButton.Size = new Size(26, 26);
            
            ChangeButton.BackgroundImage = DefaultImages.GetDefaultImage("pencil.png");
            ChangeButton.BackColor = ColorManagment.InvisibleBackGround;
            ChangeButton.BackgroundImageLayout = ImageLayout.Stretch;
            ChangeButton.Location = new Point(ButtonContainer.Width / 2 - ChangeButton.Width / 2, ButtonContainer.Height / 2 - ChangeButton.Height / 2);
            ChangeButton.Click += button_Click;
            ButtonContainer.Controls.Add(ChangeButton);

        }
        private void button_Click(object sender, EventArgs e)
        {
            Image image;
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Choose a photo";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationFilePath = Path.Combine(DefaultPaths.AvatarsPath, fileName);
                    try
                    {
                        File.Copy(sourceFilePath, destinationFilePath, overwrite: true);

                        image = DefaultImages.GetAvatar(fileName);
                        Avatar.Image = image;
                        Kasutaja kasutaja = DBHandler.GetRecord<Kasutaja>(new List<WhereField>() { new WhereField("id", FormAppContext.CurrentUser.id.ToString()) });
                        DBHandler.UpdateUserData(
                            kasutaja,
                            "pilt",
                            fileName
                            );
                        FormAppContext.CurrentUser.picture = fileName;
                        HeaderHandler.AvatarChanged();
                    }
                    catch {
                        MessageBox.Show("unluck");
                    }
                }
            }
        }
        private void InitButtonContainer()
        {
            ButtonContainer.Size = new Size(40, 40);
            ButtonContainer.Location = new Point(81, 81);
            ButtonContainer.BackColor = ColorManagment.OptionField;
            this.Controls.Add(ButtonContainer);
        }
    }
}
