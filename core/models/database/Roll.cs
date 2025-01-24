using zxcforum.core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models.database
{
    public class Roll: Table, ITable
    {
        public string tableName { get; set; } = "roll";
        public Roll() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"roll", null },
        };
        public override string OutValue
        {
            get
            {
                return _data["roll"];
            }
        }
    }
}
