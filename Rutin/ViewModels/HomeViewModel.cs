using CommunityToolkit.Mvvm.Input;
using Models.TbModels;
using Rutin.Views.Pages;
using Services;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace Rutin.ViewModels;

public class HomeViewModel : ObservableObject
{
    public ICommand AdicionarAtividadeCommand { get; set; }

    public ObservableCollection<CardAtividadeViewModel> Atividades { get; }

    public string NomeDiaSemana { get; set; } = DateTime.Now.ToString("dddd", new CultureInfo("pt-br")).ToUpper();
    public string DiaSemana { get; set; } = DateTime.Now.Day.ToString();
    public string Mes { get; set; } = DateTime.Now.ToString("MMMM", new CultureInfo("pt-br")).ToUpper();

    public HomeViewModel()
    {
        AdicionarAtividadeCommand = new AsyncRelayCommand(OnAdicionarAtividadeClicked);

        Atividades = new ObservableCollection<CardAtividadeViewModel>();
    }

    private async Task OnAdicionarAtividadeClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(NovaAtividadePage)}");
    }

    public async Task AdicionarAtividades()
    {
        List<AtividadeModel> todasAtividades = await AtividadeService.GetAllAtividades();
        foreach (var atividade in todasAtividades)
        {
            Atividades.Add(new CardAtividadeViewModel
            {
                IdAtividade = atividade.Id,
                TituloAtividade = atividade.Nome,
                HorarioAtividade = $"{atividade.HorarioInicio.ToString()} ➝ {atividade.HorarioFinal.ToString()}",
                TipoNotificacao = atividade.TipoNotificacao,
                DescricaoAtividade = atividade.Descricao
            });
        }
    }
}
