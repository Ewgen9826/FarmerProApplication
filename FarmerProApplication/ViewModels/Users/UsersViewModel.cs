using FarmerProApplication.Dtos.User;
using FarmerProApplication.Extensions;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FarmerProApplication.ViewModels
{
    public class UsersViewModel: ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IUsersService _usersService;

        public RelayCommand BackCommand { get; }
        public RelayCommand NavigateToAddPageCommand { get; }
        public RelayCommand RemoveCommand { get; set; }

        private UserDto _selectedUser;
        public UserDto SelectedUser
        {
            get => _selectedUser;
            set => Set(ref _selectedUser, value);
        }

        public ObservableCollection<UserDto> Users { get; set; }

        public UsersViewModel(NavigationService navigationService, IUsersService usersService)
        {
            _navigationService = navigationService;
            _usersService = usersService;

            NavigateToAddPageCommand = new RelayCommand(() => NavigateToAddPage());
            RemoveCommand = new RelayCommand(() => Remove());
            BackCommand = new RelayCommand(() => NavigateToHome());

            Users = _usersService.GetAll().ToObservable();
        }

        private void NavigateToHome()
        {
            _navigationService.ShowPage(PageNameConstants.AdminHomePage);
        }

        private void NavigateToAddPage()
        {
            _navigationService.ShowPage(PageNameConstants.UserDetailPage);
        }

        private void Remove()
        {
            _usersService.Remove(SelectedUser.Id);
            Users.Remove(SelectedUser);
            SelectedUser = null;
        }
    }
}
