using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.utils
{
    public static class TablesManagment
    {
        public static Type GetRecordType(string tableName)
        {
            Console.WriteLine(tableName);

            if(tableName == "roll")
            {
                Console.WriteLine("roll YEEEEEEEEE");
                return typeof(Roll);
            }
            return null;
        }

    }
}
