using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.models.database
{
    public class Table
    {
        public virtual Dictionary<string, string> _data { get; set; } = new Dictionary<string, string>();
        public List<string> GetKeys()
        {
            List<string> returnList = new List<string>();
            foreach(string key in _data.Keys)
            {
                returnList.Add(key);
            }
            return returnList;
        }
        public virtual string OutValue { get; set;}
        public string this[string key]
        {
            get
            {
                if (_data.ContainsKey(key))
                {
                    return _data[key];
                }
                return null;
         
            }
            set
            {
                if (_data.ContainsKey(key))
                {
                    _data[key] = value;
                }
            }
        }
    }
}
