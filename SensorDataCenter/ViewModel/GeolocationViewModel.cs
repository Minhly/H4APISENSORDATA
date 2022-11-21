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
       
        //GeolocationService geolocationService;

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
                    GeolocationText = "Latitude: " + location.Latitude.ToString() + " Longitude: " + location.Longitude.ToString() + " Altitude: " + location.Altitude;
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
