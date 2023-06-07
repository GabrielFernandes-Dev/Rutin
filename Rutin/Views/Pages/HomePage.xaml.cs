using Rutin.Views.Controls;

namespace Rutin.Views.Pages;

public partial class HomePage : ContentPage
{
    private HomeViewModel viewModel;
	public HomePage()
	{
		InitializeComponent();

        viewModel = new HomeViewModel();
		BindingContext = viewModel;
	}

	protected override async void OnAppearing()
	{
        base.OnAppearing();
        await viewModel.AdicionarAtividades();

        for (int i = 0; i < (BindingContext as HomeViewModel).Atividades.Count; i++)
        {
            try
            {
                AtividadeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                CardAtividadeView duplicate = new CardAtividadeView
                {
                    BindingContext = (BindingContext as HomeViewModel).Atividades[i]
                };
                Grid.SetRow(duplicate, i);
                AtividadeGrid.Children.Add(duplicate);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Catch block caught an exception in the code!");
            }
        }
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        viewModel.Atividades.Clear();
        AtividadeGrid.Children.Clear();
        AtividadeGrid.RowDefinitions.Clear();
    }
}