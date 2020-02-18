using FarmerProApplication.Dialogs;
using FarmerProApplication.Enums;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace FarmerProApplication.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IAuthService _authService;
        private readonly DialogsService _dialogsService;

        private string _login;
        private string _password;
        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public RelayCommand LoginCommand { get; }

        public LoginViewModel(NavigationService navigationService, IAuthService authService, DialogsService dialogsService)
        {
            _navigationService = navigationService;
            _authService = authService;
            _dialogsService = dialogsService;

            LoginCommand = new RelayCommand(() => SignIn());
        }

        private void SignIn()
        {
            if (_login == null || _password == null)
            {
                _dialogsService.ShowError("Введите логин и пароль.");
                return;
            }

            var user = _authService.SignIn(_login, _password);
            if (user == null)
            {
                _dialogsService.ShowError("Пользователя не существует.");
                return;
            }
            switch (user.Role)
            {
                case RoleEnum.USER:
                    _navigationService.ShowPage(PageNameConstants.UserHomePage);
                    break;
                case RoleEnum.ADMIN:
                    _navigationService.ShowPage(PageNameConstants.AdminHomePage);
                    break;
                default: return;
            }

        }
    }
}
