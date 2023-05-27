using System.Collections.ObjectModel;

namespace Rutin.ViewModels;

public class HomeViewModel : ObservableObject
{
    public ObservableCollection<CardAtividadeViewModel> Atividades { get; }

    public HomeViewModel()
    {
        Atividades = new ObservableCollection<CardAtividadeViewModel>();

        Atividades.Add(new CardAtividadeViewModel
        {
            TituloAtividade = "Atividade 1",
            HorarioAtividade = "16:00 ➝ 17:10",
            TipoNotificacao = "Tipo da notificação",
            DescricaoAtividade = "Descrição da atividade"
        });

        Atividades.Add(new CardAtividadeViewModel
        {
            TituloAtividade = "Atividade 2",
            HorarioAtividade = "18:00 ➝ 19:10",
            TipoNotificacao = "Tipo da notificação 2",
            DescricaoAtividade = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."
        });
    }
}
