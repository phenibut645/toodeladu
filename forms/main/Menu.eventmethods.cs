using zxcforum.core.controls;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.core.models;

namespace zxcforum.forms.main
{
    public partial class Menu
    {
        public void ChangePage(PageUserControl page)
        {
            if (MainPage != null)
            {
                if(MainPage == page) return;
                MainPage.Clear();
                this.Controls.Remove(MainPage);
            }
            this.MainPage = page;
            MainPage.InitAll();

            this.Controls.Add(MainPage);
        }
        public void LoggedIn()
        {
            Console.WriteLine("Logged in");
            this.RefreshForm();
        }
    }
}
