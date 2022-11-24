using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDataCenter.Services
{
    public class TemperatureService
    {

        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<TemperatureData> Temperatures { get; set; }

        public TemperatureService()
        {
            _client = new HttpClient();
            Temperatures = new List<TemperatureData>();
        }

        public async Task<List<TemperatureData>> TemperatureListPage(int sensorId)
        {
            if(Temperatures.Count > 0)
                Temperatures.Clear();

            //TemperatureView.ItemsSource = temperatures;

            // ObservableCollection allows items to be added after ItemsSource
            // is set and the UI will react to changes

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://192.168.1.146/get_latest_temperature_data.php?hostname=Temp_sensor_" + sensorId);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    TemperatureData jsonString = JsonSerializer.Deserialize<TemperatureData>(content);
                    Temperatures.Add(new TemperatureData { Temperature = jsonString.Temperature + "°C", Id = "Sensor_Id: " + jsonString.Id, Humidity = "Humidity: " + jsonString.Humidity + "%", Hostname = jsonString.Hostname, Date_Uploaded = jsonString.Date_Uploaded, Location = jsonString.Location });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            return Temperatures;
        }

        public async Task<string> PostTemperature(string temperature, string humidity)
        {
            var sensor_id = "1";

            var temperatureData = new PostTemperatureData() { sensor_id = sensor_id, Temperature = temperature, Humidity = humidity };

            var json = JsonSerializer.Serialize(temperatureData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://192.168.1.146/post_temperature_data.php";

            var response = await _client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            if(response.StatusCode == HttpStatusCode.Created)
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
