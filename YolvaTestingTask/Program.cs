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
            var result = x.GetPlaces(address);

            foreach (var item in result)
            {
                foreach (var b in item.Geojson.Polygons)
                {
                    foreach (var c in b)
                    {
                        if (c.Count < pointsFrequency || pointsFrequency == 0)
                        {
                            break;
                        }
                        else
                        {
                            for (int i = 0; i < c.Count; i += pointsFrequency)
                            {
                                c.RemoveAt(i);
                            }
                            if (c[c.Count - 1] != c[0])
                            {
                                c[c.Count - 1] = c[0];
                            }
                        }
                    }
                }
            }


            string json = JsonConvert.SerializeObject(result);

            File.Create(path).Close();
            File.WriteAllText(path, json);
            //File.W
            Console.ReadKey();
        }
    }
}
