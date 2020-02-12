using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Threading.Tasks;

namespace FarmerProApplication.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;

        private string login;
        private string password;
        public string Login
        {
            get => login;
            set => Set(ref login, value);
        }
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        public RelayCommand LoginCommand { get; }

        public LoginViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            LoginCommand = new RelayCommand(() => SignIn());
        }

        private void SignIn()
        {
            if(Login == "user" && Password == "password")
            {
                _navigationService.ShowPage(PageNameConstants.UserHomePage);
            }

            if(Login == "admin" && Password == "password")
            {
                _navigationService.ShowPage(PageNameConstants.AdminHomePage);
            }
           
        }
    }
}
