using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace YolvaTestingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите адрес: ");
            string address = Console.ReadLine();
            Console.WriteLine("Введите имя сохраняемого файла: ");
            string path = Console.ReadLine();
            Console.WriteLine("Введите частоту точек: ");
            int pointsFrequency = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            OpenStreetMapGeoService x = new OpenStreetMapGeoService();
            var result = x.GetPlaces(address, pointsFrequency);
           
            string json = JsonConvert.SerializeObject(result);

            File.Create(path).Close();
            File.WriteAllText(path, json);
            Console.ReadKey();
        }
    }
}
