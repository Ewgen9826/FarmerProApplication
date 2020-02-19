using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace FarmerProApplication.ViewModels.Ration
{
    public class ChoiceEquantityKormsViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly StateService _stateService;
        public RelayCommand NaviagationToNutritionRationCommand { get; }
        public RelayCommand NavigationToUserHomePageCommand { get; }
        public RelayCommand NavigationToChoiceKormsPageCommand { get; }

        public ObservableCollection<StateKormDto> StateKorms { get; set; }
        public ChoiceEquantityKormsViewModel(NavigationService navigationService, StateService stateService)
        {
            _navigationService = navigationService;
            _stateService = stateService;

            StateKorms = _stateService.Korms.ToObservable();

            NaviagationToNutritionRationCommand = new RelayCommand(() => NaviagationToNutritionRation());
            NavigationToUserHomePageCommand = new RelayCommand(() => NavigationToUserHomePage());
            NavigationToChoiceKormsPageCommand = new RelayCommand(() => NavigationToChoiceKormsPage());

        }

        private void NaviagationToNutritionRation()
        {
            _stateService.Korms = StateKorms.Select(korm => korm).ToList();
            _navigationService.ShowPage(PageNameConstants.NutritionRationPage);
        }

        private void NavigationToUserHomePage()
        {
            _navigationService.ShowPage(PageNameConstants.UserHomePage);
        }

        private void NavigationToChoiceKormsPage()
        {
            _navigationService.ShowPage(PageNameConstants.ChoiceKormsPage);
        }
    }
}
