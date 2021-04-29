using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace YolvaTestingTask
{
    class PlaceService
    {
        public IList<Place> GetPlaces(string address)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36");
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, address);
            var response = client.SendAsync(httpRequest).Result;

            using var responseStream = response.Content.ReadAsStreamAsync().Result;

            var b = JsonSerializer.DeserializeAsync<List<PlaceOpenStreetMapDto>>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }).Result;

            return null;
        }
    }
}
