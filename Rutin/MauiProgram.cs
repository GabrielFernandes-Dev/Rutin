using Microsoft.Extensions.Logging;
using Rutin.ViewModels;
using Rutin.Views.Pages;
using SimpleToolkit.SimpleShell;

namespace Rutin;

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
        builder.UseSimpleShell();

        builder.Services.AddSingleton<PessoaViewModel>();
		builder.Services.AddSingleton<LoginPage>();
		builder.Services.AddTransient<CadastroPage>();


#if DEBUG
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
