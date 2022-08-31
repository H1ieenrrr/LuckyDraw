using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyDraw.Interfaces
{
    public interface IAdmin
    {
        CustomerModel LoginAdmin(ViewLogin viewLogin);
        Task<int> ChangePasswordAdmin(string email, CustomerModel customerModel);

        Task<List<CustomerModel>> GetCustomerAll();

        Task<List<CampaignModel>> GetAllCampaign();
        Task<int> AddCampaign(CampaignModel campaignModel);

        Task<List<RuleModel>> GetAllRule();
        Task<int> AddRule(RuleModel rule);
        Task<int> EditRule(int id, RuleModel rule);
        Task<int> DeleteRule(int id);


        Task<List<GiftModel>> GetGiftAll();
        GiftModel GetGiftIdFind(int id);
        Task<GiftModel> GetGiftId(int id);
        Task<int> AddGift(GiftModel giftModel);
        Task<int> EditGift(int id, GiftModel giftModel);
        Task<int> DeleteGift(int id);

        Task<List<BarcodeModel>> GetBarcode();
        Task<int> AddBarcode(BarcodeModel barcode);
        Task<List<BarcodeHistory>> GetBarcodeHistory();
        Task<int> ScanBarcode(BarcodeHistory barcodeHistory);
    }
}
