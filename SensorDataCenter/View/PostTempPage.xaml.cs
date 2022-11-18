using SensorDataCenter.ViewModel;

namespace SensorDataCenter.View;

public partial class PostTempPage : ContentPage
{
	public PostTempPage(TemperatureViewModel temperatureViewModel)
	{
		InitializeComponent();
        BindingContext = temperatureViewModel;
    }
}