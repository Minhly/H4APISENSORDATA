using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDataCenter.Services
{
    public class GeolocationService
    {

        HttpClient _client;

        public GeolocationService()
        {
            _client = new HttpClient();
        }
        public async Task<string> PostGeolocation(float longitude_data, float latitude_data)
        {
            var hostname = "Phone";

            var geolocationData = new PostGeolocation() { longitude = longitude_data, latitude = latitude_data, name = hostname };

            var json = JsonSerializer.Serialize(geolocationData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://sdedavi/post_geolocation_data.php";

            var response = await _client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            await Application.Current.MainPage.DisplayAlert("Sent", "201", "ok");
            return result;
        }
    }
}
