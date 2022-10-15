using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Dict_CS
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> D_rus_eng = new Dictionary<string, string>(); //русско - английский словарь
            Dictionary<string, string> D_eng_deuch = new Dictionary<string, string>(); //англо-немецкий словарь
            


        }
        bool Dict_Load() // функция загрузки словаря
        {
            return false;
        }
        bool Dict_Save(Dictionary<string, string> D) // функция сохранения словаря
        {
            using (FileStream fs = new FileStream("D.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                JsonSerializer.Serialize(fs, D);
            }
            return false;
        }
        bool Export(string s) // экспорт слова с переводом
        {
            return false;

        }
    }
}
