using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataCenter.Model
{
    public class PostTemperatureData
    {
        [JsonPropertyName("sensor_id")]
        public string sensor_id { get; set; }

        [JsonPropertyName("temperature")]
        public string Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public string Humidity { get; set; }
    }
}
