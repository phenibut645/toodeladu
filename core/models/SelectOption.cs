using zxcforum.core.interfaces;
using zxcforum.core.models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models
{
    public class SelectOption
    {
        public string ExternalText { get; set; }
        public string Value { get; set; }
        public SelectOption(string value, string exteranlText)
        {
            Value = value;
            ExternalText = exteranlText;
        }
    }
}
