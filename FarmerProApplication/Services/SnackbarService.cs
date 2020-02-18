using Microsoft.Extensions.DependencyInjection;
using System;

namespace FarmerProApplication.Services
{
    public class SnackbarService
    {

        private readonly IServiceProvider _serviceProvider;
        public SnackbarService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Show(string message)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.ShowSnackBar(message);
        }
    }
}
