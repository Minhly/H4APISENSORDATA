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
        [JsonPropertyName("longitude_data")]
        public float longitude { get; set; }

        [JsonPropertyName("latitude_data")]
        public float latitude { get; set; }

        [JsonPropertyName("hostname")]
        public string name { get; set; }

    }
}
