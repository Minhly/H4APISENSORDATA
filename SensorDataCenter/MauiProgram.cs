﻿using SensorDataCenter.Services;
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

        return builder.Build();
	}
}