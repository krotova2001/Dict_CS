using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// это класс самого словаря
/// </summary>

namespace Dict_CS
{
    class Dict
    {
        public Dictionary <string, string> core { get; set; } // сам словарь 
        public Dict() // простой конструктор
        {
            core = new Dictionary <string, string> ();
        }
    }
}
