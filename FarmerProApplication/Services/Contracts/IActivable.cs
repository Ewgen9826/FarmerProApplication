using System.Threading.Tasks;

namespace FarmerProApplication.Services
{
    interface IActivable<T>
    {
        Task Activate(T parameter);
    }
}
