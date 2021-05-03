using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace YolvaTestingTask
{
    public class OpenStreetMapGeoService : IGeoService<PlaceOpenStreetMapDto>
    {
        string url = "https://nominatim.openstreetmap.org/search";
        private readonly PlaceService placeService;

       public OpenStreetMapGeoService()
        {
            placeService = new PlaceService();
        }

        public IList<PlaceOpenStreetMapDto> GetPlaces(string address)
        {
            Uri requestUri = new Uri($"{url}?q={address}&format=json&polygon_geojson=1");
            return placeService.GetPlaces(requestUri.AbsoluteUri);
        }
    }
}
