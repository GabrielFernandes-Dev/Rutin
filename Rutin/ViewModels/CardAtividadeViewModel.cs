using Rutin.Views.Pages;
using Services;
using System.ComponentModel;
using System.Windows.Input;

namespace Rutin.ViewModels;

public class CardAtividadeViewModel : ObservableObject
{
    private int _idAtividade;
    private string _tituloAtividade;
    private string _horarioAtividade;
    private string _tipoNotificacao;
    private string _descricaoAtividade;
    private bool _expandido;

    public ICommand Expandir { get; }

    public ICommand ExcluirCommand { get; set; }

    public CardAtividadeViewModel()
    {
        Expandir = new Command(ExpandirAtividade);
        ExcluirCommand = new Command(Excluir);
    }

    private void ExpandirAtividade()
    {
        Expandido = !Expandido;
    }

    private async void Excluir()
    {
        await AtividadeService.RemoveAtividade(IdAtividade);
        

    }

    public int IdAtividade
    {
        get => _idAtividade;
        set => SetProperty(ref _idAtividade, value);
    }

    public string TituloAtividade
    {
        get => _tituloAtividade;
        set => SetProperty(ref _tituloAtividade, value);
    }

    public string HorarioAtividade
    {
        get => _horarioAtividade;
        set => SetProperty(ref _horarioAtividade, value);
    }

    public string TipoNotificacao
    {
        get => _tipoNotificacao;
        set => SetProperty(ref _tipoNotificacao, value);
    }

    public string DescricaoAtividade
    {
        get => _descricaoAtividade;
        set => SetProperty(ref _descricaoAtividade, value);
    }

    public bool Expandido
    {
        get => _expandido;
        set
        {
            _expandido = value;
            OnPropertyChanged(nameof(Expandido));
        }
    }

}
