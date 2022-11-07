namespace Lab6Starter;

/**
 * 
 * Name: Benjamin Wastart and Alex Rodriguez
 * Date: Nov 7, 2022
 * Description: A single page application of TicTacToe.
 * Bugs: Doesn't like playing in windows machine.
 * Reflection: This was an easier lab other than having to keep making new forks.
 * 
 */


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

		return builder.Build();
	}
}

