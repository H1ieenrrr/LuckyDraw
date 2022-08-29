using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyDraw.Interfaces
{
    public interface ICustomer
    {
        CustomerModel LoginCustomer(ViewLogin viewLogin);
        Task<int> RegisterCustomer(CustomerModel customerModel);
        Task<int> ChangePassword(string phone, CustomerModel customerModel);
        Task<bool> Spin(ViewSpin spin);
        Task<bool> CheckAmountGift(ViewSpin spin);
        Task<bool> AddWinner(ViewSpin spin);
        Task<List<WinnerModel>> GetWinnerAll();
        Task<List<WinnerModel>> GetWinnerId(int id);
    }
}
