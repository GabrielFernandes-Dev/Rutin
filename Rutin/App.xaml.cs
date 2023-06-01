using Rutin.Views.Pages;

namespace Rutin;

public partial class App : Application
{
	public App()
	{
        InitializeComponent();

        MainPage = new AppShell();
	}

    protected override void OnStart()
    {
        base.OnStart();
        Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
