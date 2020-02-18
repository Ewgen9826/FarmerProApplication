using FarmerProApplication.Dtos.Cow;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels
{
    public class CowsViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly ICowsService _cowsService;

        public RelayCommand BackCommand { get; }
        public RelayCommand NavigateToAddPageCommand { get; }
        public RelayCommand RemoveCommand { get; set; }

        private CowDto _selectedCow;
        public CowDto SelectedCow
        {
            get => _selectedCow;
            set => Set(ref _selectedCow, value);
        }

        public ObservableCollection<CowDto> Cows { get; set; }
        public CowsViewModel(NavigationService navigationService, ICowsService cowsService)
        {
            _navigationService = navigationService;
            _cowsService = cowsService;

            NavigateToAddPageCommand = new RelayCommand(() => NavigateToAddPage());
            BackCommand = new RelayCommand(() => NavigateToHome());
            RemoveCommand = new RelayCommand(() => Remove());

            Cows = _cowsService.GetAll().ToObservable();
        }

        private void NavigateToHome()
        {
            _navigationService.ShowPage(PageNameConstants.AdminHomePage);
        }

        private void NavigateToAddPage()
        {
            _navigationService.ShowPage(PageNameConstants.CowDetailPage);
        }

        private void Remove()
        {
            _cowsService.Remove(SelectedCow.Id);
            Cows.Remove(SelectedCow);
            SelectedCow = null;
        }
    }
}
