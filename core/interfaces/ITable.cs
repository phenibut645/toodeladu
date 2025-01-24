using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zxcforum.core.interfaces
{
    public interface ITable
    {
        string tableName { get; set; }
        string this[string key] { get; set; }
        List<string> GetKeys();
    }
}
