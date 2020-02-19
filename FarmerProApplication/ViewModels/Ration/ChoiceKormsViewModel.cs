using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using System.Linq;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace FarmerProApplication.ViewModels.Ration
{
    public class ChoiceKormsViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IKormsService _kormsService;
        private readonly StateService _stateService;
        public RelayCommand NaviagationToChoiceEquantityKormsCommand { get; }
        public RelayCommand NavigationToUserHomePageCommand { get; }

        public ObservableCollection<ChoiceKormDto> ChoiceKormDtos { get; set; }
        public ChoiceKormsViewModel(NavigationService navigationService, IKormsService kormsService, StateService stateService)
        {
            _navigationService = navigationService;
            _kormsService = kormsService;
            _stateService = stateService;

            ChoiceKormDtos = _kormsService.GetAll()
                .Select(korm => new ChoiceKormDto 
                { 
                    Id = korm.Id,
                    Name = korm.Name, 
                    IsCheck = false, 
                    Cost = korm.Cost ,
                    Energy = korm.Energy,
                    RawMaterial=korm.RawMaterial,
                    Protein = korm.Protein
                })
                .ToObservable();

            NaviagationToChoiceEquantityKormsCommand = new RelayCommand(() => NaviagationToChoiceEquantityKorms());
            NavigationToUserHomePageCommand = new RelayCommand(() => NavigationToUserHomePage());

        }

        private void NaviagationToChoiceEquantityKorms()
        {
            _stateService.Korms = ChoiceKormDtos.Where(korm=>korm.IsCheck).Select(korm => new StateKormDto
            {
                Id = korm.Id,
                Name = korm.Name,
                Cost = korm.Cost,
                Energy = korm.Energy,
                RawMaterial = korm.RawMaterial,
                Protein = korm.Protein
            }).ToList();
            _navigationService.ShowPage(PageNameConstants.ChoiceEquantityKormsPage);

        }

        private void NavigationToUserHomePage()
        {
            _navigationService.ShowPage(PageNameConstants.UserHomePage);
        }
    }
}
