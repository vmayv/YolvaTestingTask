using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace YolvaTestingTask
{
    class GeoJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var jsonObject = JObject.Load(reader);

            var type = jsonObject.GetValue("type").ToString();
            var coordinates = jsonObject.GetValue("coordinates");
            switch (type)
            {
                case "Polygon":
                    var polygonCoordinates = coordinates.ToObject<List<List<List<double>>>>();
                    return new Geojson { Type = type, Polygons = new List<List<List<List<double>>>> { polygonCoordinates } };

                case "MultiPolygon":
                    var multiPolygonCoordinates = coordinates.ToObject<List<List<List<List<double>>>>>();
                    return new Geojson { Type = type, Polygons = multiPolygonCoordinates };

                default:
                    break;
            }
            return new Geojson { Type = type };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var geoJson = value as Geojson;
            writer.WriteStartObject();
            writer.WritePropertyName("type");
            serializer.Serialize(writer, geoJson.Type);
            writer.WritePropertyName("coordinates");
            serializer.Serialize(writer, geoJson.Polygons);
            writer.WriteEndObject();
        }
    }
}
