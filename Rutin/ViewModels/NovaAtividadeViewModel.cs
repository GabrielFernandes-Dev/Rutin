using Rutin.Views.Pages;
using Services;

namespace Rutin.ViewModels;

public class NovaAtividadeViewModel : ObservableObject
{
    public ICommand SalvarAtividade { get; }
    public ICommand Voltar { get; }

    public NovaAtividadeViewModel()
    {
        SalvarAtividade = new AsyncRelayCommand(SalvarAtividadeAction);
        Voltar = new AsyncRelayCommand(VoltarAction);
    }

	string nomeAtividade = string.Empty;
	public string NomeAtividade
	{
		get => nomeAtividade;
		set 
		{
			nomeAtividade = value;
			OnPropertyChanged(nameof(NomeAtividade));
		}
	}

	TimeSpan hrInicial = new TimeSpan(01,30,00); 
	public TimeSpan HrInicial
	{
		get => hrInicial;
        set
		{
            hrInicial = value;
            OnPropertyChanged(nameof(HrInicial));
        }
	}

    TimeSpan hrFinal = new TimeSpan(02, 35, 00);
    public TimeSpan HrFinal
    {
        get => hrFinal;
        set
        {
            hrFinal = value;
            OnPropertyChanged(nameof(HrFinal));
        }
    }

	List<string> tipoNotificacao = new List<string> 
	{
		"Alarme",
        "Notificação Silenciosa",
        "Notificação Adiantada",
        "Notificação Atrasada"
    };
	public List<string> TipoNotificacao
	{
		get => tipoNotificacao;
        set
		{
            tipoNotificacao = value;
            OnPropertyChanged(nameof(TipoNotificacao));
        }
	}

	string notificacaoSelecionada = string.Empty;
	public string NotificacaoSelecionada
	{
        get => notificacaoSelecionada;
        set
		{
            notificacaoSelecionada = value;
            OnPropertyChanged(nameof(NotificacaoSelecionada));
        }
    }

	string descricaoAtividade = string.Empty;
	public string DescricaoAtividade
	{
        get => descricaoAtividade;
        set
		{
            descricaoAtividade = value;
            OnPropertyChanged(nameof(DescricaoAtividade));
        }
    }

    public async Task SalvarAtividadeAction()
    {
        await AtividadeService.AddAtividade(NomeAtividade, HrInicial, HrFinal, NotificacaoSelecionada, DescricaoAtividade);
        Clear();
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    public async Task VoltarAction()
    {
        Clear();
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }

    private void Clear()
    {
        NomeAtividade = string.Empty;
        HrInicial = new TimeSpan(01, 30, 00);
        HrFinal = new TimeSpan(02, 35, 00);
        NotificacaoSelecionada = string.Empty;
        DescricaoAtividade = string.Empty;
    }
}
