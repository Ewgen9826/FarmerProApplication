using AutoMapper;
using FarmerProApplication.Dialogs;
using FarmerProApplication.Mapper;
using FarmerProApplication.Model;
using FarmerProApplication.Model.Seeds;
using FarmerProApplication.Pages;
using FarmerProApplication.Pages.Admin;
using FarmerProApplication.Pages.User;
using FarmerProApplication.Services;
using FarmerProApplication.Services.Contracts;
using FarmerProApplication.Services.Implementations;
using FarmerProApplication.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace FarmerProApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        public App()
        {
            host = Host.CreateDefaultBuilder()  // Use default settings
                                                //new HostBuilder()          // Initialize an empty HostBuilder
         .ConfigureAppConfiguration((context, builder) =>
         {
             // Add other configuration files...
             builder.AddJsonFile("appsettings.local.json", optional: true);
             Configuration = builder.Build();
         }).ConfigureServices((context, services) =>
         {
             ConfigureServices(context.Configuration, services);
         })
         .ConfigureLogging(logging =>
         {
             // Add other loggers...
         })
         .Build();

            ServiceProvider = host.Services;
        }

        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            // Database Configurations
            services.AddDbContext<ApplicationDatabaseContext>
        (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            // Add NavigationService for the application.
            services.AddScoped<NavigationService>(serviceProvider =>
            {
                var navigationService = new NavigationService(serviceProvider);
                navigationService.Configure(PageNameConstants.LoginPage, typeof(LoginPage));
                navigationService.Configure(PageNameConstants.AdminHomePage, typeof(AdminHomePage));
                navigationService.Configure(PageNameConstants.UserHomePage, typeof(UserHomePage));
                navigationService.Configure(PageNameConstants.UsersPage, typeof(UsersPage));
                navigationService.Configure(PageNameConstants.UserDetailPage, typeof(UserDetailPage));
                navigationService.Configure(PageNameConstants.FeedBasePage, typeof(FeedBasePage));
                navigationService.Configure(PageNameConstants.FeedBaseDetailPage, typeof(FeedBaseDetailPage));
                navigationService.Configure(PageNameConstants.CowsPage, typeof(CowsPage));
                navigationService.Configure(PageNameConstants.CowDetailPage, typeof(CowDetailPage));
                navigationService.Configure(PageNameConstants.NormsPage, typeof(NormsPage));
                navigationService.Configure(PageNameConstants.NormDetailPage, typeof(NormDetailPage));

                return navigationService;
            });

            // Register all Bissnes Logic Services 
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<INormsService, NormsService>();
            services.AddTransient<IKormsService, KormsService>();
            services.AddTransient<ICowsService, CowsService>();

            // Register all the Windows of the applications.
            services.AddSingleton<MainWindow>();
            // Register all ViewModels of the applications.
            services.AddSingleton<LoginViewModel>();
            services.AddSingleton<AdminHomeViewModel>();
            services.AddTransient<UsersViewModel>();
            services.AddTransient<UserDetailViewModel>();
            services.AddTransient<FeedBaseViewModel>();
            services.AddTransient<FeedBaseDetailViewModel>();
            services.AddTransient<CowsViewModel>();
            services.AddTransient<CowDetailViewModel>();
            services.AddTransient<NormsViewModel>();
            services.AddTransient<NormDetailViewModel>();
            // Register all Pages of the applications.
            services.AddTransient<LoginPage>();
            services.AddTransient<AdminHomePage>();
            services.AddTransient<UserHomePage>();
            services.AddTransient<UsersPage>();
            services.AddTransient<UserDetailPage>();
            services.AddTransient<FeedBasePage>();
            services.AddTransient<FeedBaseDetailPage>();
            services.AddTransient<CowsPage>();
            services.AddTransient<CowDetailPage>();
            services.AddTransient<NormsPage>();
            services.AddTransient<NormDetailPage>();
            // Register all Dialogs Window
            services.AddTransient<ConfirmDialog>();

            services.AddTransient<DialogsService>();
            services.AddTransient<SnackbarService>();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var context = ServiceProvider.GetRequiredService<ApplicationDatabaseContext>();
            InitDataBase.Seed(context);

            var mainWindow = host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            var navigationService = ServiceProvider.GetRequiredService<NavigationService>();
            navigationService.ShowPage(PageNameConstants.LoginPage);

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync();
            }
            base.OnExit(e);
        }
    }
}
