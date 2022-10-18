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
            Dict R_A = new Dict(); //русско - английский словарь
            Dict A_D; //англо-немецкий словарь
            R_A.core.Add("Один", "One");
            R_A.core.Add("Два", "Two");



            using (FileStream fs = new FileStream("D.json", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                JsonSerializer.Serialize(fs, R_A);
            }
           
            string buff = File.ReadAllText("D.json");
            Dict A = JsonSerializer.Deserialize<Dict>(buff);
            Show(A);

            /*
             
            string fileName = "WeatherForecast.json"; 
            string jsonString = JsonSerializer.Serialize(weatherForecast);
            File.WriteAllText(fileName, jsonString);
             */

        }

    }
}
