using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels.Ration
{
    public class CostRationViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StateService _stateService;
        public RelayCommand NavigationToReportOnRatinCommand { get; }
        public RelayCommand CalculateCostRationCommand { get; }
        public RelayCommand NavigationToUserHomePageCommand { get; }
        public RelayCommand NavigationToNutritionRationPageCommand { get; }

        private int _cowsCount;
        public int CowsCount { get=>_cowsCount; set=>Set(ref _cowsCount, value); }

        private int _days;
        public int Days { get=>_days; set=>Set(ref _days, value); }

        private double _costRation;
        public double CostRation { get=>_costRation; set=>Set(ref _costRation, value); }

        public CostRationViewModel(NavigationService navigationService, StateService stateService)
        {
            _navigationService = navigationService;
            _stateService = stateService;

            CalculateCostRationCommand = new RelayCommand(() => CalculateCostRation());
            NavigationToReportOnRatinCommand = new RelayCommand(()=>NavigationToReportOnRatin());
            NavigationToUserHomePageCommand = new RelayCommand(() => NavigationToUserHomePage());
            NavigationToNutritionRationPageCommand = new RelayCommand(() => NavigationToNutritionRationPage());

        }

        private void CalculateCostRation()
        {
            CostRation = _stateService.CalculateCostRation(CowsCount, Days);
        }

        private void NavigationToReportOnRatin()
        {
            _navigationService.ShowPage(PageNameConstants.ReportOnRationPage);
        }

        private void NavigationToUserHomePage()
        {
            _navigationService.ShowPage(PageNameConstants.UserHomePage);
        }

        private void NavigationToNutritionRationPage()
        {
            _navigationService.ShowPage(PageNameConstants.NutritionRationPage);
        }
    }
}
