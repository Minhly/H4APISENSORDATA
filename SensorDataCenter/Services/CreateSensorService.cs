using SensorDataCenter.Model;
using SensorDataCenter.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDataCenter.Services
{
    public class CreateSensorService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public CreateSensorService()
        {
            _client = new HttpClient();
        }

        public async Task<string> CreateSensor(string hostname, string ipAddress, string geoId)
        {
            var sensor = new Sensor() { Hostname = hostname, IpAddress = ipAddress, GeoId = geoId };

            var json = JsonSerializer.Serialize(sensor);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://192.168.1.146/post_sensor.php";

            var response = await _client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                await Application.Current.MainPage.DisplayAlert("Sent", "201", "Yay!");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", Convert.ToString(response.StatusCode), "Try again");
            }
            return "201";
        }
    }
}
