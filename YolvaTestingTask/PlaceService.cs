using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace YolvaTestingTask
{
    class PlaceService
    {
        public IList<PlaceOpenStreetMapDto> GetPlaces(string address, int pointsFrequency)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, address);
            var response = client.SendAsync(httpRequest).Result;

            using var responseStream = response.Content.ReadAsStreamAsync().Result;

            var streamReader = new StreamReader(responseStream).ReadToEnd();

            var allObjects = JsonConvert.DeserializeObject<List<PlaceOpenStreetMapDto>>(streamReader);

            var resultPolygons = new List<PlaceOpenStreetMapDto>();

            var result = new List<PlaceOpenStreetMapDto>();

            foreach (var x in allObjects)
            {
                if (x.Geojson.Polygons != null)
                {
                    resultPolygons.Add(x);
                    result.Add(x);
                }
            }

            foreach (var item in resultPolygons)
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
                            var copy = new List<List<double>>(c);
                            c.Clear();
                            for (int i = 0; i < copy.Count; i += pointsFrequency)
                            {
                                c.Add(copy[i]);
                            }
                                if (c[c.Count - 1] != c[0])
                                {
                                    c[c.Count - 1] = c[0];
                                }
                            }
                        }
                    }
                }

            return result;
        }
           
        }
    }

