using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class Skeem : Table, ITable
    {
        public string tableName { get; set; } = "skeem";
        public Skeem() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"nimi", null },
            {"riida_arv", null},
            {"veerg_arv", null}
        };
    }
}
