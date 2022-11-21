using SensorDataCenter.ViewModel;

namespace SensorDataCenter.View;

public partial class GeolocationPage : ContentPage
{
	public GeolocationPage(GeolocationViewModel geolocationViewModel)
	{
		InitializeComponent();
        BindingContext = geolocationViewModel;
    }
}