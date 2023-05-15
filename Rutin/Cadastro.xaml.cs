using Rutin.ViewModels;

namespace Rutin;

public partial class Cadastro : ContentPage

{
	public Cadastro()
	{
		InitializeComponent();
		BindingContext = new PessoaViewModel();
	}

}