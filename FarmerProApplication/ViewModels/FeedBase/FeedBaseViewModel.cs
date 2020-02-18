using FarmerProApplication.Dtos.Korm;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace FarmerProApplication.ViewModels
{
    public class FeedBaseViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IKormsService _kormsService;

        public RelayCommand BackCommand { get; }
        public RelayCommand NavigateToAddPageCommand { get; }
        public RelayCommand RemoveCommand { get; set; }

        private KormDto _selectedKorm;
        public KormDto SelectedNorm
        {
            get => _selectedKorm;
            set => Set(ref _selectedKorm, value);
        }

        public ObservableCollection<KormDto> Korms{ get; set; }

        public FeedBaseViewModel(NavigationService navigationService, IKormsService kormsService)
        {
            _navigationService = navigationService;
            _kormsService = kormsService;

            NavigateToAddPageCommand = new RelayCommand(() => NavigateToAddPage());
            BackCommand = new RelayCommand(() => NavigateToHome());
            RemoveCommand = new RelayCommand(() => Remove());

            Korms = _kormsService.GetAll().ToObservable();
        }

        private void NavigateToHome()
        {
            _navigationService.ShowPage(PageNameConstants.AdminHomePage);
        }

        private void NavigateToAddPage()
        {
            _navigationService.ShowPage(PageNameConstants.FeedBaseDetailPage);
        }

        private void Remove()
        {
            _kormsService.Remove(SelectedNorm.Id);
            Korms.Remove(SelectedNorm);
            SelectedNorm = null;
        }
    }
}
