namespace Rutin.Views.Pages;

public partial class NovaAtividadePage : ContentPage
{
	public NovaAtividadePage()
	{
		InitializeComponent();

        BindingContext = new NovaAtividadeViewModel();

		picker.SetBinding(Picker.ItemsSourceProperty, nameof(NovaAtividadeViewModel.TipoNotificacao));
		picker.SetBinding(Picker.SelectedItemProperty, nameof(NovaAtividadeViewModel.NotificacaoSelecionada));
    }
}