using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

/// <summary>
/// это класс самого словаря
/// </summary>

namespace Dict_CS
{
    class Dict
    {
        public Dictionary <string, string> D;
        public Dict()
        {
            D = new Dictionary <string, string> ();
        }
        public bool Load()
        {
            return false;
        }
        public bool Save()
        {
            return false;
        }
    }
}
