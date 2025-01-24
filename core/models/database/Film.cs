using zxcforum.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models.database
{
    public class Film: Table, ITable
    {
        public string tableName { get; set; } = "film";
        public Film() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"nimetus", null },
            {"kirjeldus", null},
            {"aasta", null },
            {"poster", null },
            {"kestvus", null}
        };
    }
}
