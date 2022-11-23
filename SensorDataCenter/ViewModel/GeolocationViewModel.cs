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

        float geolocationLongitude;
        float geolocationLatitude;
        string geolocationText1;
        string geolocationText2;

        public string GeolocationText1
        {
            get => geolocationText1;
            set
            {
                if (geolocationText1 == value)
                    return;
                geolocationText1 = value;
                OnPropertyChanged();
            }
        }
        public string GeolocationText2
        {
            get => geolocationText2;
            set
            {
                if (geolocationText2 == value)
                    return;
                geolocationText2 = value;
                OnPropertyChanged();
            }
        }
        public float GeolocationLongitude
        {
            get => geolocationLongitude;
            set
            {
                if (geolocationLongitude == value)
                    return;
                geolocationLongitude = value;
                OnPropertyChanged();
            }
        }
        public float GeolocationLatitude
        {
            get => geolocationLatitude;
            set
            {
                if (geolocationLatitude == value)
                    return;
                geolocationLatitude = value;
                OnPropertyChanged();
            }
        }

        public GeolocationViewModel(GeolocationService geoService)
        {
            Title = "Geolocation";
            this.geolocationService = geoService;
            GeolocationCommand = new Command(async () => await GetCurrentLocationAsync());
            PostGeolocationCommand = new Command(async () => await PostCurrentLocationAsync());
        }

        async Task PostCurrentLocationAsync()
        {
            try
            {
                var postCall = await geolocationService.PostGeolocation(geolocationLongitude, geolocationLatitude);
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
                    GeolocationText1 = "Latitude: " + Math.Round(location.Latitude, 4);
                    GeolocationText2 = "Longitude: " + Math.Round(location.Longitude,4);
                    GeolocationLatitude = (float)location.Latitude;
                    GeolocationLongitude = (float)location.Longitude;
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
