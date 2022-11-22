using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SensorDataCenter.Services
{
    public class SoundService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        public List<SoundData> Sounds { get; set; }

        public async Task<string> PostSound(string sound)
        {
            var sensor_id = "1";

            var soundData = new PostSoundData() { sensor_id = sensor_id, sound_level = sound };

            var json = JsonSerializer.Serialize(soundData);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://sdedavi/post_sensor_data.php";

            var response = await _client.PostAsync(url, data);

            string result = response.Content.ReadAsStringAsync().Result;
            await Application.Current.MainPage.DisplayAlert("Sent", "201", "ok");
            return result;
        }
    }
}