using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace YolvaTestingTask
{
    public class PlaceOpenStreetMapDto
    {
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }
    }
}
