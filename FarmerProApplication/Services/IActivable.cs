using System.Threading.Tasks;

namespace FarmerProApplication.Services
{
    interface IActivable
    {
        Task ActivateAsync(object parameter);
    }
}
