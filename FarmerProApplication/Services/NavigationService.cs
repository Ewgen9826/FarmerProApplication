using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FarmerProApplication.Services
{
    public class NavigationService
    {
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();

        private readonly IServiceProvider serviceProvider;

        public void Configure(string key, Type windowType) => pages.Add(key, windowType);

        public NavigationService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void ShowPage(string pageKey, object parameter = null)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            var page = serviceProvider.GetRequiredService(pages[pageKey]) as UserControl;
            mainWindow.ShowPage(page);
        }
    }
}
