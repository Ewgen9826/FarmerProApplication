using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.ViewModels
{
    public class FeedBaseDetailViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IKormsService _kormsService;
        private readonly DialogsService _dialogsService;
        private readonly SnackbarService _snackbarService;

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

        private decimal _cost;
        public decimal Cost { get => _cost; set => Set(ref _cost, value); }

        public FeedBaseDetailViewModel(NavigationService navigationService, IKormsService kormsService, DialogsService dialogsService, SnackbarService snackbarService)
        {
            _navigationService = navigationService;
            _kormsService = kormsService;
            _dialogsService = dialogsService;
            _snackbarService = snackbarService;

            CancelCommand = new RelayCommand(() => Cancel());
            AddCommand = new RelayCommand(() => Add());
        }

        private void Cancel()
        {
            _navigationService.ShowPage(PageNameConstants.FeedBasePage);
        }

        private void Add()
        {
            var createKorm = new CreateKormDto
            {
                Name = _name,
                RawMaterial = _rawMaterial,
                Protein = _protein,
                Energy = _energy,
                Cost = _cost
            };

            var results = new List<ValidationResult>();
            var context = new ValidationContext(createKorm);
            if (!Validator.TryValidateObject(createKorm, context, results, true))
            {
                _dialogsService.ShowError("Заполните все поля формы.");
                return;
            }

            _kormsService.Add(createKorm);
            _navigationService.ShowPage(PageNameConstants.FeedBasePage);

            _snackbarService.Show("Корм успешно добавлен.");
        }
    }
}
