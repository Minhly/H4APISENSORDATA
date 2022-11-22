using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataCenter.Model
{
    public class PostSoundData
    {
        [JsonPropertyName("sound_level")]
        public string sound_level { get; set; }

        [JsonPropertyName("sensor_id")]
        public string sensor_id { get; set; }
    }
}
