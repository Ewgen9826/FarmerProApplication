using FarmerProApplication.Dtos;
using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels.Ration
{
    public class NutritionRationViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StateService _stateService;
        public RelayCommand NavigationToCostRationPageCommand { get; }
        public RelayCommand NavigationToUserHomePageCommand { get; }
        public RelayCommand NavigationToChoiceEquantityKormsPageCommand { get; }

        public ObservableCollection<NutritionRationDto> NutritionRationDtos { get; set; }
        public NutritionRationViewModel(NavigationService navigationService, StateService stateService)
        {
            _navigationService = navigationService;
            _stateService = stateService;

            NutritionRationDtos = _stateService.CalculateNutrition().ToObservable();

            NavigationToCostRationPageCommand = new RelayCommand(() => NaviagationToCostRationPage());
            NavigationToUserHomePageCommand = new RelayCommand(() => NavigationToUserHomePage());
            NavigationToChoiceEquantityKormsPageCommand = new RelayCommand(() => NavigationToChoiceEquantityKormsPage());

        }

        private void NaviagationToCostRationPage()
        {
            _navigationService.ShowPage(PageNameConstants.CostRationPage);
        }

        private void NavigationToUserHomePage()
        {
            _navigationService.ShowPage(PageNameConstants.UserHomePage);
        }

        private void NavigationToChoiceEquantityKormsPage()
        {
            _navigationService.ShowPage(PageNameConstants.ChoiceEquantityKormsPage);
        }
    }
}
