﻿
using FarmerProApplication.ViewModel;
using FarmerProApplication.ViewModels.Balance;
using Microsoft.Extensions.DependencyInjection;

namespace FarmerProApplication.ViewModels
{
    public class ViewModelLocator
    {
        public LoginViewModel LoginViewModel => App.ServiceProvider.GetRequiredService<LoginViewModel>();
        public AdminHomeViewModel AdminViewModel => App.ServiceProvider.GetRequiredService<AdminHomeViewModel>();
        public UsersViewModel UsersViewModel => App.ServiceProvider.GetRequiredService<UsersViewModel>();
        public UserDetailViewModel UserDetailViewModel => App.ServiceProvider.GetRequiredService<UserDetailViewModel>();
        public FeedBaseViewModel FeedBaseViewModel => App.ServiceProvider.GetRequiredService<FeedBaseViewModel>();
        public FeedBaseDetailViewModel FeedBaseDetailViewModel => App.ServiceProvider.GetRequiredService<FeedBaseDetailViewModel>();
        public CowsViewModel CowsViewModel => App.ServiceProvider.GetRequiredService<CowsViewModel>();
        public CowDetailViewModel CowDetailViewModel => App.ServiceProvider.GetRequiredService<CowDetailViewModel>();
        public NormsViewModel NormsViewModel => App.ServiceProvider.GetRequiredService<NormsViewModel>();
        public NormDetailViewModel NormDetailViewModel => App.ServiceProvider.GetRequiredService<NormDetailViewModel>();
        public ChoiceGroupCowViewModel ChoiceGroupCowViewModel => App.ServiceProvider.GetRequiredService<ChoiceGroupCowViewModel>();
        public BalanceResultViewModel BalanceResultViewModel => App.ServiceProvider.GetRequiredService<BalanceResultViewModel>();
        public UserHomeViewModel UserHomeViewModel => App.ServiceProvider.GetRequiredService<UserHomeViewModel>();
    }
}
