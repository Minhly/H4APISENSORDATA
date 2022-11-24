using SensorDataCenter.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorDataCenter.Services;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;

namespace SensorDataCenter.ViewModel
{
    public class TemperatureViewModel : BaseViewModel
    {
        public ObservableCollection<TemperatureData> Temperatures { get; } = new();
        public Command GetTemperaturesCommand { get; }
        public Command PostTemperaturesCommand { get; }

        TemperatureService temperatureService;

        string temperatureText;
        string humidityText;
        string tempSensorId;

        public string TempSensorId 
        {
            get => tempSensorId;
            set
            {
                if (tempSensorId == value)
                    return;
                tempSensorId = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureText
        {
            get => temperatureText;
            set
            {
                if (temperatureText == value)
                    return;
                temperatureText = value;
                OnPropertyChanged();
            }
        }

        public string HumidityText
        {
            get => humidityText;
            set
            {
                if (humidityText == value)
                    return;
                humidityText = value;
                OnPropertyChanged();
            }
        }

        public TemperatureViewModel(TemperatureService temperatureService)
        {
            Title = "Temperature Sensor Center";
            this.temperatureService = temperatureService;
            GetTemperaturesCommand = new Command(async () => await GetTemperaturesAsync());
            PostTemperaturesCommand = new Command(async () => await PostTemperatureDataAsync());
        }

        async Task GetTemperaturesAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                int testforint = Convert.ToInt32(TempSensorId);
                var temperatures = await temperatureService.TemperatureListPage(testforint);

                if (Temperatures.Count != 0)
                    Temperatures.Clear();

                foreach (var temp in temperatures)
                {
                    Temperatures.Add(temp);
                }
                TempSensorId = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task PostTemperatureDataAsync()
        {
            try
            {
                var postCall = await temperatureService.PostTemperature(TemperatureText, HumidityText);
                TemperatureText = "";
                HumidityText = "";
                TempSensorId = "";
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

    }

}
