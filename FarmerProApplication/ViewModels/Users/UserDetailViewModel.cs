using FarmerProApplication.Dtos.User;
using FarmerProApplication.Enums;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FarmerProApplication.ViewModels
{
    public class UserDetailViewModel:ViewModelBase
    {
        private readonly NavigationService _navigationService;
        private readonly IUsersService _usersService;
        private readonly DialogsService _dialogsService;
        private readonly SnackbarService _snackbarService;

        public RelayCommand CancelCommand { get; }
        public RelayCommand AddCommand { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }

        public UserDetailViewModel(NavigationService navigationService, IUsersService usersService, DialogsService dialogsService, SnackbarService snackbarService)
        {
            _navigationService = navigationService;
            _usersService = usersService;
            _dialogsService = dialogsService;
            _snackbarService = snackbarService;

            CancelCommand = new RelayCommand(() => Cancel());
            AddCommand = new RelayCommand(() => Add());
        }

        private void Cancel()
        {
            _navigationService.ShowPage(PageNameConstants.UsersPage);
        }

        private void Add()
        {
            var createUser = new CreateUserDto();
            createUser.FirstName = FirstName;
            createUser.LastName = LastName;
            createUser.Login = Login;
            createUser.Password = Password;
            createUser.Role = IsAdmin ? RoleEnum.ADMIN : RoleEnum.USER;

            var results = new List<ValidationResult>();
            var context = new ValidationContext(createUser);
            if (!Validator.TryValidateObject(createUser, context, results, true))
            {
                _dialogsService.ShowError("Заполните все поля формы.");
                return;
            }

            _usersService.Add(createUser);
            _navigationService.ShowPage(PageNameConstants.UsersPage);

            _snackbarService.Show("Пользователь успешно добавлен.");
        }
    }
}
