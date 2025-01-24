using zxcforum.core.enums;
using zxcforum.core.models.database;
using zxcforum.core.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models
{
    public class User
    {
        public int id;
        public string name;
        string password;
        public Rolls roll;
        public string picture;
        public string vanus;
        public User(string name, string password, Rolls role)
        {
            this.name = name;
            this.password = password;
            this.roll = role;
        }
        public bool Check(string name, string password)
        {
            if (this.name == name && this.password == password)
            {
                return true;
            }
            return false;
        }
        public static User ConvertUser(Kasutaja kasutaja)
        {
            string role = DBHandler.GetSingleResponse($"SELECT roll FROM roll WHERE id = {kasutaja["roll"]}", "roll");
            Roll roleObject =DBHandler.GetRecord<Roll>(new List<WhereField>() { new WhereField("id", kasutaja["roll"])});
            Console.WriteLine($"ROLE = {roleObject["roll"]}");
            User user = new User(kasutaja["nimi"], kasutaja["salasona"], (Rolls)RolesManagment.GetRole(role));
            user.id = int.Parse(kasutaja["id"]);
            user.picture = kasutaja["pilt"];
            user.vanus = kasutaja["vanus"];
            return user;
        }
    }
}
