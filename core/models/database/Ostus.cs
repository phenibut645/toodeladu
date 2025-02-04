using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class Ostus: Table, ITable
    {
        public string tableName { get; set; } = "ostus";
        public Ostus() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"kasutaja", null },
            {"toode", null},
            {"kogus", null }
        };

    }
}
