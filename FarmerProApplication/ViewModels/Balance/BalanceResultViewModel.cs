using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels.Balance
{
    public class BalanceResultViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StateService _stateService;

        public NormDto Norm { get; set; }
        public RelayCommand NavigationToBalanceResultPageCommand { get; set; }

        public BalanceResultViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigationToBalanceResultPageCommand = new RelayCommand(() => NavigationToBalanceResultPage());
        }

        private void NavigationToBalanceResultPage()
        {
            _navigationService.ShowPage(PageNameConstants.BalanceResultPage);

            Norm = _stateService.Norm;
        }
    }
}
