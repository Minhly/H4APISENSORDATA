using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataCenter.Model
{
    public class PostGeolocation
    {
        [JsonPropertyName("longitude")]
        public double longitude { get; set; }

        [JsonPropertyName("latitude")]
        public double latitude { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

    }
}
