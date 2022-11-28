using SensorDataCenter.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorDataCenter.ViewModel
{
    public class CreateSensorViewModel : BaseViewModel
    {
        public Command CreateSensorCommand { get; }
        CreateSensorService createSensorService;

        string hostname;
        string ipAddress;
        string geoId;

        public string HostnameEntry
        {
            get => hostname;
            set
            {
                if (hostname == value)
                    return;
                hostname = value;
                OnPropertyChanged();
            }
        }

        public string IpAddressEntry
        {
            get => ipAddress;
            set
            {
                if (ipAddress == value)
                    return;
                ipAddress = value;
                OnPropertyChanged();
            }
        }

        public string GeoIdEntry
        {
            get => geoId;
            set
            {
                if (geoId == value)
                    return;
                geoId = value;
                OnPropertyChanged();
            }
        }

        public CreateSensorViewModel(CreateSensorService createSensorService)
        {
            this.createSensorService = createSensorService;
            CreateSensorCommand = new Command(async () => await CreateSensorAsync());
        }

        async Task CreateSensorAsync()
        {
            try
            {
                var postCall = await createSensorService.CreateSensor(HostnameEntry, IpAddressEntry, GeoIdEntry);
                if(postCall != "400")
                {
                    HostnameEntry = "";
                    IpAddressEntry = "";
                    GeoIdEntry = "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "Ok");
            }
        }
    }
}
