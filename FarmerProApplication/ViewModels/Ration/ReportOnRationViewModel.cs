using FarmerProApplication.Dtos;
using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels.Ration
{
    public class ReportOnRationViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StateService _stateService;

        public RelayCommand NavigationToNutritionRationPageCommand { get; }
        public RelayCommand NavigationToUserHomePageCommand { get; }

        public ObservableCollection<StateKormDto> StateKorms { get; set; }
        public ObservableCollection<NutritionRationDto> NutritionRationDtos { get; set; }

        private double _costRation;
        public double CostRation { get => _costRation; set => Set(ref _costRation, value); }

        public ReportOnRationViewModel(NavigationService navigationService, StateService stateService)
        {
            _navigationService = navigationService;
            _stateService = stateService;

            StateKorms = _stateService.Korms.ToObservable();
            NutritionRationDtos = _stateService.CalculateNutrition().ToObservable();
            CostRation = _stateService.CostRation;

            NavigationToNutritionRationPageCommand = new RelayCommand(() => NavigationToNutritionRationPage());
            NavigationToUserHomePageCommand = new RelayCommand(() => NavigationToUserHomePage());
        }

        private void NavigationToNutritionRationPage()
        {
            _navigationService.ShowPage(PageNameConstants.NutritionRationPage);
        }

        private void NavigationToUserHomePage()
        {
            _navigationService.ShowPage(PageNameConstants.UserHomePage);
        }
    }
}
