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
        public float longitude { get; set; }

        [JsonPropertyName("latitude")]
        public float latitude { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

    }
}
