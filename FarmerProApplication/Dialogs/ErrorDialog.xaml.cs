using System.Windows.Controls;

namespace FarmerProApplication.Dialogs
{
    /// <summary>
    /// Interaction logic for ErrorDialog.xaml
    /// </summary>
    public partial class ErrorDialog : UserControl
    {
        public ErrorDialog(string message)
        {
            InitializeComponent();
            messageTxt.Text = message;
        }
    }
}
