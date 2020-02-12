using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels
{
    public class NormsViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;

        public RelayCommand BackCommand { get; }
        public RelayCommand NavigateToAddPageCommand { get; }

        public NormsViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToAddPageCommand = new RelayCommand(() => NavigateToAddPage());
            BackCommand = new RelayCommand(() => NavigateToHome());
        }

        private void NavigateToHome()
        {
            _navigationService.ShowPage(PageNameConstants.AdminHomePage);
        }

        private void NavigateToAddPage()
        {
            _navigationService.ShowPage(PageNameConstants.NormDetailPage);
        }
    }
}
