using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataCenter.Model
{
    public class SoundData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("sound_level")]
        public string Sound { get; set; }

        [JsonPropertyName("date_uploaded")]
        public string Date_Uploaded { get; set; }

        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }
    }
}
