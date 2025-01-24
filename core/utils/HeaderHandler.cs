using zxcforum.core.controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.enums;
using zxcforum.forms.main.pages;
using zxcforum.core.models;
using System.Runtime.CompilerServices;
using zxcforum.core.context;

namespace zxcforum.core.utils
{
    public delegate void ChangePage(PageUserControl userControl);
    public static class HeaderHandler
    {
        public static Dictionary<PageDataTemplate, List<HeaderButton>> ButtonsInHeader { get; private set;} = new Dictionary<PageDataTemplate, List<HeaderButton>>();
        public static HeaderButton ActiveButton { get; private set; } = null;

        public static event ChangePage Notify;

        static HeaderHandler()
        {
        }
        public static void ClearEverything()
        {
            foreach(KeyValuePair<PageDataTemplate, List<HeaderButton>> entry in ButtonsInHeader)
            {
                if(entry.Value == null) continue;
                foreach(HeaderButton button in entry.Value)
                {
                    button.Delete();
                }
            }
            FormAppContext.MainForm.Controls.Clear();
            ActiveButton = null;
        }
        public static bool IsButtonLoaded(HeaderButton button)
        {
            if(ButtonsInHeader != null)
            {
                foreach(KeyValuePair<PageDataTemplate, List<HeaderButton>> entry in ButtonsInHeader)
                {
                    if(entry.Value == null) continue;
                    foreach(HeaderButton headerButton in entry.Value)
                    {
                        if(headerButton == button) return true;
                    }
                }
            }
            else throw new Exception("The buttons haven't been loaded.");
            return false;
        }
        private static void headerButton_click(object sender, MouseEventArgs e)
        {
            HeaderButton button = (HeaderButton)sender;
            if(button != null)
            {
                Rolls role = FormAppContext.Role;
                if (button.RolesRequired.Contains(role))
                {
                    
                    Console.WriteLine($"the click event have been called by {button.Name.Text} button");

                    if(FormAppContext.MainForm != null)
                    {
                        if (IsButtonLoaded(button))
                        {
                            Console.WriteLine($"{button.Page} bruh");
                            FormAppContext.MainForm.ChangePage(button.Page);
                            if (ActiveButton != null)
                            {
                                foreach (HeaderButton headerButton in ButtonsInHeader[ActiveButton.PageDataTemplate])
                                {
                                    headerButton.ChangeActiveStatusAuto();
                                }
                            }
                            foreach (HeaderButton headerButton in ButtonsInHeader[button.PageDataTemplate])
                            {
                                if(!headerButton.Temp) ActiveButton = button;
                                headerButton.ChangeActiveStatusAuto();
                            }
                        }
                    }
                    else throw new Exception("The form wasn't given.");
                }
                else
                {
                    Login form = new Login();
                    form.Show();
                }
            }
        }
        public static void LoadTemplates(List<PageDataTemplate> templates)
        {
            if(FormAppContext.MainForm != null)
            {
                foreach(PageDataTemplate template in templates)
                {
                    ButtonsInHeader[template] = null;
                }
            }
            else throw new Exception("A form wasn't given to 'Header Handler' class.");

        }
        public static void PushButtons(List<HeaderButton> buttons)
        {
            if(FormAppContext.MainForm != null)
            {
                foreach(HeaderButton headerButton in buttons)
                {
                    headerButton.AddMethodOnClick(headerButton_click);
                    
                    ButtonsInHeader[headerButton.PageDataTemplate]?.Add(headerButton);
                    if (ButtonsInHeader[headerButton.PageDataTemplate] == null)
                    {
                        ButtonsInHeader[headerButton.PageDataTemplate] = new List<HeaderButton>() { headerButton };
                        Console.WriteLine($"new list {headerButton.PageDataTemplate.Type.ToString()}");
                    }
                }
            }
        }
        public static void ChangeToForeignPage(PageUserControl page)
        {
            FormAppContext.MainForm.ChangePage(page);
        }
        public static void AvatarChanged()
        {
            foreach(KeyValuePair<PageDataTemplate, List<HeaderButton>> template in ButtonsInHeader)
            {
                if(template.Key.Type == HeaderButtonType.Profile)
                {
                    foreach(HeaderButton button in template.Value)
                    {
                        button.Icon.Image = DefaultImages.GetAvatar(FormAppContext.CurrentUser);
                    }
                }
            }
        }
        public static void ClearTempButtons()
        {
            List<HeaderButton> tempButtons = new List<HeaderButton>();
            foreach (KeyValuePair<PageDataTemplate, List<HeaderButton>> template in ButtonsInHeader)
            {
                foreach(HeaderButton button in template.Value)
                {
                    if (button.Temp)
                    {
                        tempButtons.Add(button);
                    }
                } 
                foreach(HeaderButton tempButton in tempButtons)
                {
                    template.Value.Remove(tempButton);
                }
            }
            
        }
    }
}
