using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class Saalituup : Table, ITable
    {
        public string tableName { get; set; } = "saalituup";
        public Saalituup() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"tuup", null },
        };
    }
}
