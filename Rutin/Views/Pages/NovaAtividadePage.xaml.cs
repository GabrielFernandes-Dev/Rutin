namespace Rutin.Views.Pages;

public partial class NovaAtividadePage : ContentPage
{
	public NovaAtividadePage()
	{
		InitializeComponent();

        var tiponotificacao = new List<string>();
        tiponotificacao.Add("Alarme");
        tiponotificacao.Add("Notificação Silenciosa");
        tiponotificacao.Add("Notificação Adiantada");
        tiponotificacao.Add("Notificação Atrasada");

        picker.ItemsSource = tiponotificacao;
    }
}