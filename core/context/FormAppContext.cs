using zxcforum.core.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zxcforum.forms.main;
using zxcforum.core.enums;
using zxcforum.core.utils;
using zxcforum.core.models.database;

namespace zxcforum.core.context
{
    
    public static class FormAppContext
    {
        public static event Action LoggedIn;
        private static User _currentUser;
        public static Dictionary<Toode, int> Korv { get; set; } = new Dictionary<Toode, int>();
        public static User CurrentUser
        {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                Console.WriteLine("Invoking");
                LoggedIn?.Invoke();
            }
        }
        public static Rolls Role
        {
            get
            {
                if(CurrentUser != null)
                {
                    return CurrentUser.roll;
                }
                else
                {
                    return Rolls.Guest;
                }
            }
        }
        public static forms.main.Menu MainForm { get; set; } = null;
        public static void AddProductToKorv(Toode toode, int kogus)
        {
            foreach(KeyValuePair<Toode, int> entry in Korv)
            {
                if (entry.Key["nimetus"] == toode["nimetus"])
                {
                    Korv[entry.Key] = entry.Value + kogus;
                    return;
                }
            }
            Korv.Add(toode, kogus);
        }
    }
}
