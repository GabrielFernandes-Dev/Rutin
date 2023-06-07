using CommunityToolkit.Mvvm.Input;
using Rutin.Views.Pages;
using Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Rutin.ViewModels;

public partial class PessoaViewModel :ObservableObject, INotifyPropertyChanged
{

    public ICommand CadastrarCommand => new AsyncRelayCommand(OnCadastrarClicked);
    public ICommand VoltarCommand => new AsyncRelayCommand(OnVoltarClicked);
    public PessoaViewModel(){ }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Nome))]
    string nomeInput;

    public string Nome => NomeInput;

    private string cpf;

    public string CpfInput
    {
        get => cpf;
        set 
        {
            cpf = value;
            OnPropertyChanged(nameof(cpf));
            CpfIsValidInput = ValidarCpf.Validar(cpf);
            CpfIsInvalidInput = cpf.Length > 0 && !CpfIsValidInput;
          
        }
    }

    ValidarCpf ValidarCpf = new ValidarCpf();


    private bool cpfIsValid;

    public bool CpfIsValidInput
    {
        get => cpfIsValid;
        set
        {
            cpfIsValid = value;
            OnPropertyChanged();
        }
    }

    private bool cpfIsInvalid;

    public bool CpfIsInvalidInput
    {
        get => cpfIsInvalid;
        set
        {
            cpfIsInvalid = value;
            OnPropertyChanged();
        }
    }

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Email))]
    string emailInput;

    public string Email => EmailInput;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Senha))]
    string senhaInput;

    public string Senha => SenhaInput;

    private string confirmaSenha;
    public string ConfirmaSenhaInput
    {
        get => confirmaSenha;
        set
        {
            confirmaSenha = value;
            OnPropertyChanged(nameof(confirmaSenha));
            IsSenhaValidInput = Senha == confirmaSenha;
            IsSenhaInvalidInput = confirmaSenha.Length > 0 && !IsSenhaValidInput;
        }
    }

    private bool isSenhaValid;

    public bool IsSenhaValidInput
    {
        get => isSenhaValid;
        set
        {
            isSenhaValid = value;
            OnPropertyChanged();
        }
    }

    private bool isSenhaInvalid;

    public bool IsSenhaInvalidInput
    {
        get => isSenhaInvalid;
        set
        {
            isSenhaInvalid = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string cpf = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(cpf));
    }

    public string ConfirmaSenha => ConfirmaSenhaInput;

    private async Task OnCadastrarClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    private async Task OnVoltarClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}
