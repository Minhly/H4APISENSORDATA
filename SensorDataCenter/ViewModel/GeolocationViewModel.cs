using SensorDataCenter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = System.Diagnostics.Debug;

namespace SensorDataCenter.ViewModel
{
    public class GeolocationViewModel : BaseViewModel
    {
        private CancellationTokenSource _cancelTokenSource;
        public Command GeolocationCommand { get; }
        public Command PostGeolocationCommand { get; }

        GeolocationService geolocationService;

        string geolocationText = "Press to get geolocation";
        
        public string GeolocationText
        {
            get => geolocationText;
            set
            {
                if (geolocationText == value)
                    return;
                geolocationText = value;
                OnPropertyChanged();
            }
        }
        public GeolocationViewModel(/*GeolocationService geolocationService*/)
        {
            Title = "Geolocation";
            //this.geolocationService = geolocationService;
            GeolocationCommand = new Command(async () => await GetCurrentLocationAsync());
            PostGeolocationCommand = new Command(async () => await PostCurrentLocationAsync());
        }

        async Task PostCurrentLocationAsync()
        {
            try
            {
                var postCall = await geolocationService.PostGeolocation( 10, 10);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }

        public async Task GetCurrentLocationAsync()
        {
            if (IsBusy)
                return;

            try 
            {
                GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));

                _cancelTokenSource = new CancellationTokenSource();

                Location location = await Geolocation.Default.GetLocationAsync(request, _cancelTokenSource.Token);

                if (location != null)
                    GeolocationText = "Latitude: " + location.Latitude.ToString() + "\nLongitude: " + location.Longitude.ToString() + "\nAltitude: " + location.Altitude;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void CancelRequest()
        {
            if (IsBusy && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
                _cancelTokenSource.Cancel();
        }
    }

}
