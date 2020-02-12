using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels
{
   public class CowDetailViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;

        public RelayCommand CancelCommand { get; }

        public CowDetailViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            CancelCommand = new RelayCommand(() => Cancel());
        }

        private void Cancel()
        {
            _navigationService.ShowPage(PageNameConstants.CowsPage);
        }
    }
}
