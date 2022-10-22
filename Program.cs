using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dict_CS
{
    class Program
    {
        static void Show (Dict A) // служебная функция просмотра словаря
        {
            foreach (string key in A.core.Keys)
            {
                Console.WriteLine($"{key} - {A.core[key]}"); // перебрать все ключи и значения в словаре
            }
        }
        static void Main(string[] args)
        {
            //на страте создадим сразу два словаря
            Dict R_A; //русско - английский словарь
            Dict A_D; //англо-немецкий словарь
            //загрузим словари из файла при старте программмы
            string buff = File.ReadAllText("R_A.json");
            string buff2 = File.ReadAllText("A_D.json");
            R_A = JsonSerializer.Deserialize<Dict>(buff);
            A_D = JsonSerializer.Deserialize<Dict>(buff2);

            Console.WriteLine("ПРОГРАММА - СЛОВАРИ");
            Console.WriteLine();
            Console.WriteLine();

            Visual Menu = new Visual();
            int choise = 1000;
            do
            {
                Console.Clear();
                Menu.Show();// показываем меню
                string input = Console.ReadLine(); // считывание выбора пользователя
                choise = int.Parse(input);
                switch (choise)
                {
                    case 1:
                            Menu.Show_1();
                            string input2 = Console.ReadLine(); // считывание выбора пользователя
                            int choise2 = int.Parse(input);
                            switch (choise2)
                            {
                                case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 0:
                                break;
                            }
                        break;

                    case 2:
                        Menu.Show_1();
                        break;
                    case 3:
                        break;
                    case 4:
                        Menu.Show_1();
                        break;
                    case 0:
                        using (FileStream fs = new FileStream("R_A.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            JsonSerializer.Serialize(fs, R_A);
                        }
                        using (FileStream fs = new FileStream("A_D.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
                        {
                            JsonSerializer.Serialize(fs, A_D);
                        }
                        break;
                }
            }
            while (choise != 0);

            /*
            string fileName = "WeatherForecast.json"; 
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
             */

        }

    }
}
