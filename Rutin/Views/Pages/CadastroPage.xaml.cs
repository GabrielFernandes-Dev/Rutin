using Rutin.ViewModels;

namespace Rutin.Views.Pages;

public partial class CadastroPage : ContentPage

{
	public CadastroPage()
	{
		InitializeComponent();

		BindingContext = new PessoaViewModel();
	}

}