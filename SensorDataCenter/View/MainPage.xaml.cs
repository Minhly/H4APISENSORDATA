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

