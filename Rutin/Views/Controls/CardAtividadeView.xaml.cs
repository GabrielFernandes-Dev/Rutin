namespace Rutin.Views.Controls;

public partial class CardAtividadeView : ContentView
{
	public CardAtividadeView()
	{
		InitializeComponent();

		BindingContext = new CardAtividadeViewModel();
	}
}