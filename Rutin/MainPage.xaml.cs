namespace Rutin;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
            Fiz_modificação.Text = $"Clicked {count} time";
		else
            Fiz_modificação.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(Fiz_modificação.Text);
	}
}

