using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dict_CS
{
    class Visual
    {
        public void Show()
        {
            Console.WriteLine("Просмотр слова\t\t - 1");
            Console.WriteLine("Поиск слова\t\t - 2");
            Console.WriteLine("Добавление слова\t\t - 3");
            Console.WriteLine("Удаление слова\t\t - 4");
            Console.WriteLine("Выход\t\t - 0");
        }
        public void Show_1()
        {
            Console.WriteLine("Русский - 1");
            Console.WriteLine("English - 2");
            Console.WriteLine("Deutch - 3");
            Console.WriteLine("Назад - 0");
        }
       
    }
}
