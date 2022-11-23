using SensorDataCenter.View;

namespace SensorDataCenter;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(GeolocationPage), typeof(GeolocationPage));
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(PostTempPage), typeof(PostTempPage));
    }
}
