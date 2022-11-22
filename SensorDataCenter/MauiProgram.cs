using SensorDataCenter.Services;
using SensorDataCenter.View;
using SensorDataCenter.ViewModel;

namespace SensorDataCenter;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddTransient<TemperatureService>();
        builder.Services.AddTransient<TemperatureViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<PostTempPage>();
        builder.Services.AddTransient<PostSoundPage>();
        builder.Services.AddTransient<SoundViewModel>();
        builder.Services.AddTransient<GeolocationPage>();
        builder.Services.AddTransient<GeolocationViewModel>();
        builder.Services.AddTransient<GeolocationService>();
        builder.Services.AddTransient<FrontPage>();

        return builder.Build();
	}
}
