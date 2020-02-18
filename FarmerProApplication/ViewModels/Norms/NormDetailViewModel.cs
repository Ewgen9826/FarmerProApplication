using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FarmerProApplication.ViewModels
{
    public class NormDetailViewModel : ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly INormsService _normsService;

        public RelayCommand CancelCommand { get; }
        public RelayCommand AddCommand { get; }

        private string _name;
        public string Name { get => _name; set => Set(ref _name, value); }

        private double _rawMaterial;
        public double RawMaterial { get => _rawMaterial; set => Set(ref _rawMaterial, value); }

        private double _energy;
        public double Energy { get => _energy; set => Set(ref _energy, value); }

        private double _protein;
        public double Protein { get => _protein; set => Set(ref _protein, value); }

        public NormDetailViewModel(NavigationService navigationService, INormsService normsService)
        {
            _navigationService = navigationService;
            _normsService = normsService;

            CancelCommand = new RelayCommand(() => Cancel());
            AddCommand = new RelayCommand(() => Add());
        }

        private void Cancel()
        {
            _navigationService.ShowPage(PageNameConstants.NormsPage);
        }

        private void Add()
        {
            var createNorm = new CreateNormDto
            {
                Name = _name,
                RawMaterial = _rawMaterial,
                Energy = _energy,
                Protein = _protein
            };
            _normsService.Add(createNorm);
            _navigationService.ShowPage(PageNameConstants.NormsPage);
        }
    }
}
