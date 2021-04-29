using System;

namespace YolvaTestingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OpenStreetMapGeoService x = new OpenStreetMapGeoService();
            var t = x.GetPlaces("Москва");
            Console.ReadKey();
        }
    }
}
