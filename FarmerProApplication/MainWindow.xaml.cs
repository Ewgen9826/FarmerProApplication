using System.Windows;
using System.Windows.Controls;

namespace FarmerProApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowSnackBar(string message)
        {
            SnackbarFour.MessageQueue.Enqueue(message);
        }

        public void ShowPage(UserControl page)
        {
            main.Children.Clear();
            main.Children.Add(page);
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
