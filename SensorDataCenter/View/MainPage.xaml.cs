using static SensorDataCenter.MainPage;
using System.Text.Json;
using System.Diagnostics;
using System.Collections.ObjectModel;
using SensorDataCenter.Model;
using SensorDataCenter.ViewModel;

namespace SensorDataCenter;

public partial class MainPage : ContentPage
{
    public MainPage(TemperatureViewModel temperatureViewModel)
    {
        InitializeComponent();
        BindingContext = temperatureViewModel;
    }
}

