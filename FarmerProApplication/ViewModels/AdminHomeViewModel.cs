using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels
{
    public class AdminHomeViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;

        public RelayCommand NavigateToUsersPageCommand { get; }
        public RelayCommand NavigateToFeedBasePageCommand { get; }
        public RelayCommand NavigateToCowsPageCommand { get; }
        public RelayCommand NavigateToNormsPageCommand { get; }
        public RelayCommand LogoutCommand { get; }

        public AdminHomeViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToUsersPageCommand = new RelayCommand(() => NavigateToUsersPage());
            NavigateToFeedBasePageCommand = new RelayCommand(()=> NavigateToFeedBasePage());
            NavigateToCowsPageCommand = new RelayCommand(() => NavigateToCowsPage());
            NavigateToNormsPageCommand = new RelayCommand(() => NavigateToNormsPage());
            LogoutCommand = new RelayCommand(() => Logout());
        }

        private void NavigateToUsersPage()
        {
            _navigationService.ShowPage(PageNameConstants.UsersPage);
        }

        private void NavigateToFeedBasePage()
        {
            _navigationService.ShowPage(PageNameConstants.FeedBasePage);
        }

        private void NavigateToCowsPage()
        {
            _navigationService.ShowPage(PageNameConstants.CowsPage);
        }
         
        private void NavigateToNormsPage()
        {
            _navigationService.ShowPage(PageNameConstants.NormsPage);
        }

        private void Logout()
        {
            _navigationService.ShowPage(PageNameConstants.LoginPage);
        }
    }
}
