using FarmerProApplication.Dtos.Norm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels
{
    public class NormsViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly INormsService _normsService;

        public RelayCommand BackCommand { get; }
        public RelayCommand NavigateToAddPageCommand { get; }
        public RelayCommand RemoveCommand { get; }

        private NormDto _selectedNorm;
        public NormDto SelectedNorm
        {
            get => _selectedNorm;
            set => Set(ref _selectedNorm, value);
        }
        public ObservableCollection<NormDto> Norms { get; set; }

        public NormsViewModel(NavigationService navigationService, INormsService normsService)
        {
            _navigationService = navigationService;
            _normsService = normsService;

            NavigateToAddPageCommand = new RelayCommand(() => NavigateToAddPage());
            BackCommand = new RelayCommand(() => NavigateToHome());
            RemoveCommand = new RelayCommand(() => Remove());

            Norms = _normsService.GetAll().ToObservable();
        }

        private void NavigateToHome()
        {
            _navigationService.ShowPage(PageNameConstants.AdminHomePage);
        }

        private void NavigateToAddPage()
        {
            _navigationService.ShowPage(PageNameConstants.NormDetailPage);
        }

        private void Remove()
        {
            _normsService.Remove(SelectedNorm.Id);
            Norms.Remove(SelectedNorm);
            SelectedNorm = null;
        }
    }
}
