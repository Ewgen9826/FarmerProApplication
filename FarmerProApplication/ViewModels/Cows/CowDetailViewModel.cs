using FarmerProApplication.Dtos.Cow;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels
{
   public class CowDetailViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly ICowsService _cowsService;

        public RelayCommand CancelCommand { get; }
        public RelayCommand AddCommand { get; }

        private string _groupName;
        public string GroupName { get => _groupName; set => Set(ref _groupName, value); }

        private double _weight;
        public double Weight { get => _weight; set => Set(ref _weight, value); }

        private double _productivity;
        public double Productivity { get => _productivity; set => Set(ref _productivity, value); }


        public CowDetailViewModel(NavigationService navigationService, ICowsService cowsService)
        {
            _navigationService = navigationService;
            _cowsService = cowsService;

            CancelCommand = new RelayCommand(() => Cancel());
            AddCommand = new RelayCommand(() => Add());
        }

        private void Cancel()
        {
            _navigationService.ShowPage(PageNameConstants.CowsPage);
        }

        private void Add()
        {
            var createCow = new CreateCowDto
            {
                GroupName = _groupName,
                Weight = _weight,
                Productivity = _productivity
            };
            _cowsService.Add(createCow);
            _navigationService.ShowPage(PageNameConstants.CowsPage);
        }
    }
}
