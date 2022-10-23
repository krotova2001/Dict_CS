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
                var word2 = a.core.Where(p => p.Value == word).Select(p => p.Key); // поиск ключа в словаре по значению через LINQ
                Console.WriteLine(word2.Last()); // получаем набор с одним словом
            }
            else if (b.core.ContainsValue(word)) // если слово на немецком
            {
                var word2 = b.core.Where(p => p.Value == word).Select(p => p.Key); // поиск ключа в словаре по значению через LINQ
                Console.WriteLine(word2.Last());
                var word3 = a.core.Where(p => p.Value == word2.Last()).Select(p => p.Key); // поиск ключа в словаре по значению через LINQ
                Console.WriteLine(word3.Last());
            }
            else // если слова нигде нет
                Console.WriteLine("Не могу найти");
            Console.ReadLine();
        }
        static void Del(Dict a, Dict b) // почти та же функция поиска, только удаляет слова
        {
            Console.Clear();
            Console.WriteLine("Введите слово");
            string word = Console.ReadLine();
            if (a.core.ContainsKey(word)) // если слово на русском
            {
                string temp = a.core[word];
                if (a.core.Remove(word) && b.core.Remove(temp))
                {
                    Console.WriteLine("Слово удалено");
                }
                else
                {
                    Console.WriteLine("Не могу удалить");
                }
            }
            else if (b.core.ContainsKey(word)) // если слово на английском
            {
                var word2 = a.core.Where(p => p.Value == word).Select(p => p.Key);
                if (b.core.Remove(word) && a.core.Remove(word2.Last()))
                {
                    Console.WriteLine("Слово удалено. Нажмите Enter");
                }
                else
                {
                    Console.WriteLine("Не могу удалить");
                }
            }
            else if (b.core.ContainsValue(word)) // если слово на немецком
            {
                var word2 = b.core.Where(p => p.Value == word).Select(p => p.Key);
                var word3 = a.core.Where(p => p.Value == word2.Last()).Select(p => p.Key);
               if (b.core.Remove(word2.Last()) && a.core.Remove(word3.Last()))
                {
                    Console.WriteLine("Слово удалено. Нажмите Enter");
                }
                else
                {
                    Console.WriteLine("Не могу удалить");
                }
            }
            else // если слова нигде нет
                Console.WriteLine("Не могу найти");
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Print.Phrase("СЛОВАРЬ");
            Print.Clear(1.5);
            //на страте создадим сразу два словаря
            Dict R_A; //русско - английский словарь
            Dict A_D; //англо-немецкий словарь

            //загрузим словари из файла при старте программмы
            string buff = File.ReadAllText("R_A.json");
            string buff2 = File.ReadAllText("A_D.json");
            R_A = JsonSerializer.Deserialize<Dict>(buff);
            A_D = JsonSerializer.Deserialize<Dict>(buff2);

            Visual Menu = new Visual(); // создаем экземпляр отображения меню
            int choise = 1000; // любое, кроме ноля, чтоб  программа не завершивалсь
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
                    case 2:  // поиск слова
                           Search(R_A, A_D);
                        break;
                    case 3: // добавление слова
                        Add(R_A, A_D);
                        break;
                    case 4: // удаление слова
                        Del(R_A, A_D);
                        break;
                    case 0:
                        //экспорт словарей
                        File.Delete("R_A.json"); // для верности удалим старые словари
                        File.Delete("A_D.json");
                        using (FileStream fs = new FileStream("R_A.json", FileMode.Create, FileAccess.ReadWrite))
                        {
                            JsonSerializer.Serialize(fs, R_A);
                        }
                        using (FileStream fs = new FileStream("A_D.json", FileMode.Create, FileAccess.ReadWrite))
                        {
                            JsonSerializer.Serialize(fs, A_D);
                        }
                        break;
                }
            }
            while (choise != 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Print.Phrase("♥");
            Print.Clear(1.5);
            /*
             этот варинат оставим из справки MSDN
            string fileName = "WeatherForecast.json"; 
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
             */

        }

    }
}
