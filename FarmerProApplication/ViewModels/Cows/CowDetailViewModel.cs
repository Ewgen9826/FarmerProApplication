using FarmerProApplication.Dtos.Cow;
using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels
{
   public class CowDetailViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly ICowsService _cowsService;
        private readonly INormsService _normsService;

        public RelayCommand CancelCommand { get; }
        public RelayCommand AddCommand { get; }

        public ObservableCollection<NormDto> Norms { get; set; }

        private string _groupName;
        public string GroupName { get => _groupName; set => Set(ref _groupName, value); }

        private double _weight;
        public double Weight { get => _weight; set => Set(ref _weight, value); }

        private double _productivity;
        public double Productivity { get => _productivity; set => Set(ref _productivity, value); }

        private NormDto _norm;
        public NormDto Norm { get=>_norm; set=>Set(ref _norm,value); }


        public CowDetailViewModel(NavigationService navigationService, ICowsService cowsService, INormsService normsService)
        {
            _navigationService = navigationService;
            _cowsService = cowsService;
            _normsService = normsService;

            CancelCommand = new RelayCommand(() => Cancel());
            AddCommand = new RelayCommand(() => Add());

            Norms = _normsService.GetAll().ToObservable();
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
                Productivity = _productivity,
                NormId = _norm.Id
            };
            _cowsService.Add(createCow);
            _navigationService.ShowPage(PageNameConstants.CowsPage);
        }
    }
}
