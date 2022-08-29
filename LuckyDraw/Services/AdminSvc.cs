using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuckyDraw.Services
{
    public class AdminSvc : IAdmin
    {
        protected DataContext _context;
        protected IEncode _enCode;
        public AdminSvc(DataContext context, IEncode enCode)
        {
            _context = context;
            _enCode = enCode;
        }
        public CustomerModel LoginAdmin(ViewLogin viewLogin)
        {
            var loginAdmin = _context.CustomerModels.Where(
                p => p.CustomerEmail.Equals(viewLogin.Email)
                && p.CustomerPassword.Equals(_enCode.Encode(viewLogin.PassWord))
                ).FirstOrDefault();

            return loginAdmin;
        }

        public CustomerModel GetCustomerEmail(string email)
        {
            CustomerModel customer = null;
            customer = _context.CustomerModels.FirstOrDefault(m => m.CustomerEmail == email);
            return customer;
        }

        public async Task<int> ChangePasswordAdmin(string email, CustomerModel customerModel)
        {
            int ret = 0;
            try
            {
                CustomerModel _cus = null;
                _cus = GetCustomerEmail(email);

                _cus.CustomerPassword = _enCode.Encode(customerModel.CustomerPassword);

                _context.Update(_cus);
                await _context.SaveChangesAsync();
                ret = customerModel.CustomerID;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<CampaignModel>> GetAllCampaign()
        {
            List<CampaignModel> list = new List<CampaignModel>();
            list = await _context.CampaignModels.ToListAsync();
            return list;
        }

        public async Task<int> AddCampaign(CampaignModel campaignModel)
        {
            int ret = 0;
            try
            {

                _context.Add(campaignModel);
                await _context.SaveChangesAsync();
                ret = campaignModel.CampaignId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<RuleModel>> GetAllRule()
        {
            List<RuleModel> list = new List<RuleModel>();
            list = await _context.RuleModels.ToListAsync();
            return list;
        }

        public async Task<int> AddRule(RuleModel rule)
        {

            int ret = 0;
            try
            {
                GiftModel gift = new GiftModel();
                gift = await _context.GiftModels.Where(g => g.GiftId == rule.RuleGiftId).FirstOrDefaultAsync();

                rule.RuleSelectGift = gift.GiftProductName;


                _context.Add(rule);
                await _context.SaveChangesAsync();
                ret = rule.RuleId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<GiftModel>> GetGiftAll()
        {
            List<GiftModel> list = new List<GiftModel>();
            list = await _context.GiftModels.ToListAsync();
            return list;
        }
        public GiftModel GetGiftIdFind(int id)
        {
            GiftModel giftModel = null;
            giftModel = _context.GiftModels.Find(id);
            return giftModel;
        }
        public async Task<GiftModel> GetGiftId(int id)
        {
            GiftModel giftModel = null;
            giftModel = await _context.GiftModels.FirstOrDefaultAsync(m => m.GiftId == id);
            return giftModel;
        }

        public async Task<int> AddGift(GiftModel giftModel)
        {
            int ret = 0;
            try
            {
                giftModel.IsDelete = true;

                _context.Add(giftModel);
                await _context.SaveChangesAsync();
                ret = giftModel.GiftId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> EditGift(int id, GiftModel giftModel)
        {
            int ret = 0;
            try
            {
                GiftModel _gift = null;
                _gift = await GetGiftId(id);

                _gift.GiftCode = giftModel.GiftCode;
                _gift.GiftProductName = giftModel.GiftProductName;
                _gift.GiftDescription = giftModel.GiftDescription;
                _gift.GiftCount = giftModel.GiftCount;
                _gift.GiftCreateDate = giftModel.GiftCreateDate;
                _gift.GiftActive = giftModel.GiftActive;
                _gift.GiftUsed = giftModel.GiftUsed;
                //_gift.GiftRule = giftModel.GiftRule;
                _gift.GiftCampaign = giftModel.GiftCampaign;

                _context.Update(_gift);
                await _context.SaveChangesAsync();
                ret = giftModel.GiftId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> DeleteGift(int id)
        {
            int ret = 0;
            try
            {
                var gift = GetGiftIdFind(id);
                _context.Remove(gift);
                await _context.SaveChangesAsync();
                ret = gift.GiftId;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<List<BarcodeModel>> GetBarcode()
        {
            List<BarcodeModel> list = new List<BarcodeModel>();
            list = await _context.BarcodeModels.ToListAsync();
            return list;
        }

        public async Task<int> AddBarcode(BarcodeModel barcode)
        {
            int ret = 0;
            try
            {
                _context.Add(barcode);
                await _context.SaveChangesAsync();
                ret = barcode.BarcodeId;
            }
            catch(Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> ScanBarcode(BarcodeHistory barcodeHistory)
        {
            int ret = 0;
            try
            {
                _context.Add(barcodeHistory);
                await _context.SaveChangesAsync();
                ret = barcodeHistory.BarcodeHistoryId;
                //if(ret > 0)
                //{
                //    BarcodeModel barcode = new BarcodeModel();
                //    barcode = await _context.BarcodeModels.Where(x => x.cam)
                //}
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
     }
}
