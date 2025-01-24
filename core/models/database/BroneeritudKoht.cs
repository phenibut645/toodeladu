using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class BroneeritudKoht: Table, ITable
    {
        public string tableName { get; set; } = "broneeritudKoht";
        public BroneeritudKoht() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"koht", null },
            {"kasutaja", null},
            {"seanss", null }
        };
    }
}
