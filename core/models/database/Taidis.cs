using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class Taidis: Table, ITable
    {
        public string tableName { get; set; } = "taidis";
        public Taidis() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"ladu", null },
            {"toode", null},
            {"kogus", null }
        };

    }
}
