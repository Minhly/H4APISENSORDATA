using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public async Task<string> PostGeolocation(float longitude_data, float latitude_data, string location)
        {

            if (longitude_data == 0 || latitude_data == 0 || location == null )
            {
                await Application.Current.MainPage.DisplayAlert("Error", "BadRequest", "Try again");
            }
            else
            {
                var geolocationData = new PostGeolocation() { longitude = longitude_data, latitude = latitude_data, location = location };

                var json = JsonSerializer.Serialize(geolocationData);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://192.168.1.146/post_geolocation_data.php";

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
                return result;
            }
            return "Yes";
        }
    }
}
