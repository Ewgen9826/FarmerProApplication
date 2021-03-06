﻿using FarmerProApplication.Dtos.Norm;
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
        public RelayCommand NavigationToChoiseKormsPageCommand { get; set; }

        public BalanceResultViewModel(NavigationService navigationService, StateService stateService)
        {
            _navigationService = navigationService;
            _stateService = stateService;

            Norm = _stateService.Norm;

            NavigationToBalanceResultPageCommand = new RelayCommand(() => NavigationToBalanceResultPage());
            NavigationToChoiseKormsPageCommand = new RelayCommand(()=> NavigationToChoiseKormsPage());
        }

        private void NavigationToBalanceResultPage()
        {
            _navigationService.ShowPage(PageNameConstants.BalanceResultPage);
        }

        private void NavigationToChoiseKormsPage()
        {
            _navigationService.ShowPage(PageNameConstants.ChoiceKormsPage);
        }
    }
}
