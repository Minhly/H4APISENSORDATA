using Microsoft.Maui.Maps;
using SensorDataCenter.ViewModel;

namespace SensorDataCenter.View;

public partial class GeolocationPage : ContentPage
{
	public GeolocationPage(GeolocationViewModel geolocationViewModel)
	{
		InitializeComponent();
        BindingContext = geolocationViewModel;
    }

	protected override void OnNavigatedTo(NavigatedToEventArgs args)
	{
		base.OnNavigatedTo(args);

		var place = new Location(55.1, 11.1);

		var mapSpan = MapSpan.FromCenterAndRadius(place, Distance.FromKilometers(3));
		map.MoveToRegion(mapSpan);
		/*map.Pins.Add(new Pin
		{
			Label = "Welcome to .NET MAUI!",
			Location = place
		});*/
	}
}