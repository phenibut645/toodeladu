using zxcforum.core.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.utils
{
    static class RolesManagment
    {
        public static Rolls? GetRole(string role)
        {
            if(role == "admin")
            {
                return Rolls.Admin;
            }
            else if(role == "kasutaja"){
                return Rolls.User;
            }
            else if(role == "tootaja")
            {
                return Rolls.Worker;
            }
            return null;
        }
        public static Rolls? GetRole(int role)
        {
            if(role == 2)
            {
                return Rolls.Admin;
            }
            else if(role == 1){
                return Rolls.User;
            }
            else if(role == 3)
            {
                return Rolls.Worker;
            }
            return null;
        }
        public static string GetRole(Rolls role)
        {
            if(role == Rolls.Admin)
            {
                return "admin";
            }
            else if(role == Rolls.User){
                return "kasutaja";
            }
            else if(role == Rolls.Worker)
            {
                return "tootaja";
            }
            return null;
        }
        public static int GetRoleId(Rolls role)
        {
            if(role == Rolls.Admin)
            {
                return 2;
            }
            else if(role == Rolls.User){
                return 1;
            }
            else if(role == Rolls.Worker)
            {
                return 3;
            }
            return -1;
        }
    }
}
