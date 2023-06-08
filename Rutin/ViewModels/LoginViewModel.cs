using Rutin.Views.Pages;
using Services;

namespace Rutin.ViewModels;

public class LoginViewModel : ObservableObject
{
    public ICommand CadastrarCommand { get; }
    public ICommand LoginCommand { get; }

    public LoginViewModel()
    {
        CadastrarCommand = new AsyncRelayCommand(OnRegistrarClicked);
        LoginCommand = new AsyncRelayCommand(OnLoginClicked);
    }

    string email = string.Empty;
    public string Email
    {
        get => email;
        set
        {
            SetProperty(ref email, value);
            OnPropertyChanged(nameof(Email));
        }
    }

    string senha = string.Empty;
    public string Senha
    {
        get => senha;
        set
        {
            SetProperty(ref senha, value);
            OnPropertyChanged(nameof(Senha));
        }
    }

    bool credenciaisIncorretas = false;
    public bool CredenciaisIncorretas
    {
        get => credenciaisIncorretas;
        set
        {
            SetProperty(ref credenciaisIncorretas, value);
            OnPropertyChanged(nameof(CredenciaisIncorretas));
        }
    }

    private async Task OnRegistrarClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(CadastroPage)}");
    }

    private async Task OnLoginClicked()
    {
        if(await LoginRegistroService.ValidarUsuario(Email, Senha))
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
        else
            CredenciaisIncorretas = true;
    }
}
