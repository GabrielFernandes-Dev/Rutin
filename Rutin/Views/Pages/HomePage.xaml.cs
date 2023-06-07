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
}