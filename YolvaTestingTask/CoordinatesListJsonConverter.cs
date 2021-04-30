using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace YolvaTestingTask
{
    class CoordinatesListJsonConverter : JsonConverter
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
            var type = jsonObject["type"].ToString();
            var result = new List<Point>();

            if (type == "Point")
            {
                return jsonObject.ToObject<List<double>>();
            }
            if (type == typeof(List<List<double>>).ToString())
            {

            }
            if (type == typeof(List<List<List<double>>>).ToString())
            {

            }
            if (type == typeof(List<List<List<List<double>>>>).ToString())
            {

            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
