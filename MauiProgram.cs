﻿namespace CodeQuotes;

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
                fonts.AddFont("always-forever.ttf", "QuoteFont");
				fonts.AddFont("Sweetly Broken.ttf", "QuoteFont2");
            });

		return builder.Build();
	}
}
