using FarmerProApplication.Dialogs;
using MaterialDesignThemes.Wpf;
using System.Threading.Tasks;

namespace FarmerProApplication.Services
{
    public class DialogsService
    {
        private readonly ConfirmDialog _confirmDialog;
        public DialogsService(ConfirmDialog confirm)
        {
            _confirmDialog = confirm;
        }   
        public async Task<bool> ShowConfirm(string text)
        {
            var result =await DialogHost.Show(_confirmDialog, "RootDialog");
            return (bool)result;
        }

        public async void ShowError(string message)
        {
            var view = new ErrorDialog(message);
            await DialogHost.Show(view, "RootDialog");
        }
    }
}
