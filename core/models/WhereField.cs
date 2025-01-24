using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models
{
    public class WhereField
    {
        public string Field { get; set; }
        public string Value { get; set; }
        public bool isString = false;
        public WhereField(string field, string value)
        {
            Field = field;
            Value = value;
        }
    }
}
