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
            Console.ReadLine();
        }

        static void Add(Dict a, Dict b) // функция добавления в словарь
        {
            //считываем варианты слова в трех языках и добавляем их в словари
            Console.Clear();
            Console.WriteLine("Слово на русском");
            string rus = Console.ReadLine();
            Console.WriteLine("Слово на английском");
            string eng = Console.ReadLine();
            Console.WriteLine("Слово на немецком");
            string deu = Console.ReadLine();
            a.core.Add(rus, eng);
            b.core.Add(eng, deu);
        }

        static void Search(Dict a, Dict b)
        {
            Console.Clear();
            Console.WriteLine("Введите слово");
            string word = Console.ReadLine();
            if (a.core.ContainsKey(word)) // если слово на русском
            {
                Console.WriteLine(a.core[word]);
                Console.WriteLine(b.core[a.core[word]]);
            }
            else if (b.core.ContainsKey(word)) // если слово на английском
            {
                Console.WriteLine(b.core[word]);
                Console.WriteLine(a.core.Where(p => p.Value == word).Select(p => p.Key));
            }
            else if (b.core.ContainsValue(word)) // если слово на немецком
            {
                var word2 = b.core.Where(p => p.Value == word).Select(p => p.Key);
                Console.WriteLine(word2.DefaultIfEmpty());
                //Console.WriteLine(b.core.Where(p => p.Value == word2.).Select(p => p.Key));
            }
            else // если слова нигде нет
                Console.WriteLine("Не могу найти");
            Console.ReadLine();
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
                                Show(A_D);
                                break;
                            case 2:
                                Show(R_A);
                                break;
                            default:
                                break;
                            }
                        break;

                    case 2:
                           Search(R_A, A_D);
                        break;
                    case 3:
                        Add(R_A, A_D);
                        break;
                    case 4:
                        Menu.Show_1();
                        input2 = Console.ReadLine(); // считывание выбора пользователя
                        choise2 = int.Parse(input);
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
