using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModel
{
    public class UserHomeViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;

        public RelayCommand NavigateToChoiceGroupCowCommand { get; }
        public RelayCommand NavigateToFeedBasePageCommand { get; }
        public RelayCommand NavigateToCowsPageCommand { get; }

        public UserHomeViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateToChoiceGroupCowCommand = new RelayCommand(() => NavigateToChoiceGroupCow());
        }

        private void NavigateToChoiceGroupCow()
        {
            _navigationService.ShowPage(PageNameConstants.ChoiceGroupCowPage);
        }
    }
}
