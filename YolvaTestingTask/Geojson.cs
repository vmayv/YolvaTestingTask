using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace YolvaTestingTask
{
    public class Geojson
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public List<object> Coordinates { get; set; }

        /*
        [JsonProperty("coordinates")]
        public List<List<List<double>>> Coordinates { get; set; }*/
    }
}
