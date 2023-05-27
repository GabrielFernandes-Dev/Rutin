namespace Rutin.Components;

public partial class CardAtividadeView : ContentView
{
	public CardAtividadeView()
	{
		InitializeComponent();

		BindingContext = new CardAtividadeViewModel();
	}
}