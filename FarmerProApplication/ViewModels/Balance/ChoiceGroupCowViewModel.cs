using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels.Balance
{
    public class ChoiceGroupCowViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly INormsService _normsService;
        private readonly StateService _stateService;

        public ObservableCollection<String> Weights { get; } = new ObservableCollection<string>() { "200-299", "300-399", "400-499", " 500-599", "600-699" };
        public ObservableCollection<String> Productivities { get; } = new ObservableCollection<string>() { "10-14", "15-19", "20-29","30-34" };

        public RelayCommand NavigationToBalanceResultPageCommand { get; }

        private string _weigth;
        public string Weigth { get => _weigth; set => Set(ref _weigth, value); }

        private string _productivity;
        public string Productivity { get => _productivity; set => Set(ref _productivity, value); }

        public ChoiceGroupCowViewModel(NavigationService navigationService, INormsService normsService, StateService stateService)
        {
            _navigationService = navigationService;
            _normsService = normsService;
            _stateService = stateService;

            NavigationToBalanceResultPageCommand = new RelayCommand(() => NavigationToBalanceResultPage());
        }

        private void NavigationToBalanceResultPage()
        {
            var weigthInterval = _weigth.Split('-');
            var productivityInterval = _productivity.Split('-');
            _stateService.Norm = _normsService.GetByInterval(Convert.ToDouble(weigthInterval[0]), Convert.ToDouble(weigthInterval[1]), Convert.ToDouble(productivityInterval[0]), Convert.ToDouble(productivityInterval[1]));
            _navigationService.ShowPage(PageNameConstants.BalanceResultPage);
        }
    }
}
