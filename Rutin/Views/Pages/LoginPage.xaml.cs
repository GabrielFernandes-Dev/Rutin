using Rutin.ViewModels;

namespace Rutin.Views.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		BindingContext = new LoginViewModel();
	}
}