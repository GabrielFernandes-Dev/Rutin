namespace Rutin.Views.Pages;

public partial class NovaAtividadePage : ContentPage
{
	public NovaAtividadePage()
	{
		InitializeComponent();

        var tiponotificacao = new List<string>();
        tiponotificacao.Add("Alarme");
        tiponotificacao.Add("Notifica��o Silenciosa");
        tiponotificacao.Add("Notifica��o Adiantada");
        tiponotificacao.Add("Notifica��o Atrasada");

        picker.ItemsSource = tiponotificacao;
    }
}