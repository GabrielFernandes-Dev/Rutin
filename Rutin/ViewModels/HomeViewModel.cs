using Models.TbModels;
using Rutin.Views.Pages;
using Services;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Rutin.ViewModels;

#pragma warning disable S1133 // Deprecated code should be removed
[Obsolete("Metodo de recarregar a pagina obsoleto")]
#pragma warning restore S1133 // Deprecated code should be removed
public class HomeViewModel : ObservableObject
{
    public ICommand AdicionarAtividadeCommand { get; set; }
    public ICommand RefreshCommand { get; set; }

    public ObservableCollection<CardAtividadeViewModel> Atividades { get; }

    public string NomeDiaSemana { get; set; } = DateTime.Now.ToString("dddd", new CultureInfo("pt-br")).ToUpper();
    public string DiaSemana { get; set; } = DateTime.Now.Day.ToString();
    public string Mes { get; set; } = DateTime.Now.ToString("MMMM", new CultureInfo("pt-br")).ToUpper();


    public HomeViewModel()
    {
        AdicionarAtividadeCommand = new AsyncRelayCommand(OnAdicionarAtividadeClicked);
        RefreshCommand = new AsyncRelayCommand(AtualizarAtividades);

        Atividades = new ObservableCollection<CardAtividadeViewModel>();
    }

    bool isRefreshing;
    public bool IsRefreshing
    {
        get => isRefreshing;
        set => SetProperty(ref isRefreshing, value);
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

    public async Task AtualizarAtividades()
    {
        IsRefreshing = true;
        await Task.Delay(1500);
        Atividades.Clear();
        await AdicionarAtividades();
        IsRefreshing = false;
    }
}
