using CommunityToolkit.Mvvm.Input;
using Rutin.Views.Pages;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Rutin.ViewModels;

public class HomeViewModel : ObservableObject
{
    public ICommand AdicionarAtividadeCommand { get; set; }

    public ObservableCollection<CardAtividadeViewModel> Atividades { get; }

    public HomeViewModel()
    {
        AdicionarAtividadeCommand = new AsyncRelayCommand(OnAdicionarAtividadeClicked);

        Atividades = new ObservableCollection<CardAtividadeViewModel>();

        Atividades.Add(new CardAtividadeViewModel
        {
            TituloAtividade = "Atividade 1",
            HorarioAtividade = "16:00 ➝ 17:10",
            TipoNotificacao = "Tipo da notificação",
            DescricaoAtividade = "Descrição da atividade"
        });
    }

    private async Task OnAdicionarAtividadeClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(NovaAtividadePage)}");
    }
}
