using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SensorDataCenter.Model
{
    public class Sensor
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("hostname")]
        public string Hostname { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("geo_fk_id")]
        public string GeoId { get; set; }
    }
}
