using zxcforum.core.interfaces;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models
{
    public class Seans: Table, ITable
    {
        public string tableName { get; set; } = "seanss";
        public Seans() { }
        public override Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>()
        {
            {"id", null },
            {"film", null },
            {"filmikeel", null},
            {"saal", null },
            {"aeg", null },
            {"kuupaev", null}
        };
    }
}
