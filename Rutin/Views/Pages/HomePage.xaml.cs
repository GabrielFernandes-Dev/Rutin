using Rutin.Views.Controls;

namespace Rutin.Views.Pages;

#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Metodo de recarregar a pagina obsoleto")]
#pragma warning restore S1133 // Deprecated code should be removed
public partial class HomePage : ContentPage
{
    private HomeViewModel viewModel;

    public HomePage()
	{
		InitializeComponent();

        viewModel = new HomeViewModel();
		BindingContext = viewModel;

        MessagingCenter.Subscribe<CardAtividadeViewModel>(this, "RefreshAtividades", async (sender) =>
        {
            await viewModel.AtualizarAtividades();
        });
    }

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        await viewModel.AdicionarAtividades();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        viewModel.Atividades.Clear();
    }
}