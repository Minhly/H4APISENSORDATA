using SensorDataCenter.Services;
using SensorDataCenter.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataCenter.ViewModel
{
    public class FrontPageViewModel : BaseViewModel
    {
        public Command GetTemperatureButton { get; }
        public Command PostTemperatureButton { get; }
        public Command GeoLocationButton { get; }
        public FrontPageViewModel()
        {
            GetTemperatureButton = new Command(async () => await RedirectToGetTemperaturePage());
            PostTemperatureButton = new Command(async () => await RedirectToPostTemperaturePage());
            GeoLocationButton = new Command(async () => await RedirectToGeoLocationPage());
        }
        async Task RedirectToGetTemperaturePage()
        {
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }

        async Task RedirectToPostTemperaturePage()
        {
            await Shell.Current.GoToAsync($"{nameof(PostTempPage)}");
        }
        async Task RedirectToGeoLocationPage()
        {
            await Shell.Current.GoToAsync($"{nameof(GeolocationPage)}");
        }
    }
}
