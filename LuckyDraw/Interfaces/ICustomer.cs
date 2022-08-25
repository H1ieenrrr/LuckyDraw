using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using System.Threading.Tasks;

namespace LuckyDraw.Interfaces
{
    public interface ICustomer
    {
        CustomerModel LoginCustomer(ViewLogin viewLogin);
        CustomerModel LoginAdmin(ViewLogin viewLogin);
        Task<int> RegisterCustomer(CustomerModel customerModel);

        Task<int> ChangePasswordAdmin(string email, CustomerModel customerModel);
        Task<int> ChangePassword(string phone, CustomerModel customerModel);
    }
}
