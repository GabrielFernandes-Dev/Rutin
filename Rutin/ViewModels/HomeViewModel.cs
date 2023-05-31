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
    }
}
