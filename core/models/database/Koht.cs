using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zxcforum.core.interfaces;

namespace zxcforum.core.models.database
{
    public class Koht : Table, ITable
    {
        public string tableName { get; set; } = "koht";
        public Koht() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"coord_x", null },
            {"coord_y", null},
            {"kohatuup", null },
            {"skeem", null }
        };
    }
}
