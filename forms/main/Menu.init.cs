using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.controls;
using zxcforum.core.enums;
using System.IO;
using zxcforum.core.presets;
using zxcforum.core.context;
using zxcforum.core.models;
using zxcforum.forms.main.pages;
namespace zxcforum.forms.main
{
    public partial class Menu
    {
        public void InitAll()
        {
            this.InitHeader();
        }
        public void InitHeader()
        {
            this.Header = new Panel();
            Header.Size = new Size(1720, 80);
            Header.Location = new Point(0, 0);
            Header.BackColor = ColorManagment.HeaderBackGround;
            this.Controls.Add(Header);

            this.HeaderLine = new Label();
            HeaderLine.Height = 11;
            HeaderLine.Width = 1723;
            HeaderLine.BackColor = ColorManagment.DefaultPurple;
            HeaderLine.Location = new Point(0, 73);
            this.Header.Controls.Add(HeaderLine);

            Rolls role = FormAppContext.Role;

            List<PageDataTemplate> templates = DefaultPageTemplates.GetTemplates(role);
            templates.Add(DefaultPageTemplates.ProfileTemplate);

            List<HeaderButton> buttons = DefaultPageTemplates.GetButtons(role);
            HeaderButton moreButton = DefaultPageTemplates.GetButton(DefaultPageTemplates.MoreTemplate);
            HeaderButton profileButton = DefaultPageTemplates.GetButton(DefaultPageTemplates.ProfileTemplate);
            
            int currentX = 0;
            int index = -1;
            foreach(HeaderButton button in buttons)
            {
                index++;
                if(index > 3)
                {
                    moreButton.Location = new Point(currentX, 0);
                    buttons.Add(moreButton);
                    templates.Add(DefaultPageTemplates.MoreTemplate);
                    this.Header.Controls.Add(moreButton);
                    break;
                }
                button.Location = new Point(currentX, 0);
                currentX += button.Width + 25;
                this.Header.Controls.Add(button);
            }
            profileButton.Location = new Point(ClientSize.Width - profileButton.Width, 0);
            buttons.Add(profileButton);

            HeaderHandler.LoadTemplates(templates);
            HeaderHandler.PushButtons(buttons);
            this.Header.Controls.Add(profileButton);
        }
        public Label GetLineBetweenButtons(int x = 0, int y = 0)
        {
            Label line = new Label();
            line.Size = new Size(6, 73);
            line.BackColor = ColorManagment.LineBetweenButtons;
            return line;
        }
    }
}
