using Rutin.Views.Pages;

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

    private async Task OnRegistrarClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(CadastroPage)}");
    }

    private async Task OnLoginClicked()
    {
        await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}
