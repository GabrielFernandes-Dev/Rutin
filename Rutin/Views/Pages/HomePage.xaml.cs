using Rutin.Views.Controls;

namespace Rutin.Views.Pages;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();

		BindingContext = new HomeViewModel();
	}

	protected override void OnAppearing()
	{
        base.OnAppearing();

		for (int i = 0; i < (BindingContext as HomeViewModel).Atividades.Count; i++)
		{
			AtividadeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			CardAtividadeView card = new CardAtividadeView 
			{
				BindingContext = (BindingContext as HomeViewModel).Atividades[i]
            };
			Grid.SetRow(card, i);
			AtividadeGrid.Children.Add(card);
		}
    }
}