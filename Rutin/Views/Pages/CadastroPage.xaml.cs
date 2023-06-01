using Rutin.ViewModels;

namespace Rutin.Views;

public partial class CadastroPage : ContentPage

{
	public CadastroPage()
	{
		InitializeComponent();

		BindingContext = new PessoaViewModel();
	}

}