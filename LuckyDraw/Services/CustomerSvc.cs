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
    public class CustomerSvc : ICustomer
    {
        protected DataContext _context;
        protected IEncode _enCode;
        public CustomerSvc(DataContext context, IEncode enCode)
        {
            _context = context;
            _enCode = enCode;
        }
        public CustomerModel GetCustomerId(int id)
        {
            CustomerModel customer = null;
            customer = _context.CustomerModels.Find(id);
            return customer;
        }

        public CustomerModel GetCustomerPhone(string phone)
        {
            CustomerModel customer = null;
            customer = _context.CustomerModels.FirstOrDefault(m => m.CustomerPhone == phone);
            return customer;
        }

        public async Task<int> RegisterCustomer(CustomerModel customerModel)
        {
            int ret = 0;
            try
            {
                customerModel.CustomerBlock = false;
                customerModel.IsDelete = true;
                customerModel.CustomerPassword = _enCode.Encode(customerModel.CustomerPassword);
                customerModel.Role = 2;

                _context.Add(customerModel);
                await _context.SaveChangesAsync();
                ret = customerModel.CustomerID;
            }
            catch (Exception ex)
            {
                ret = 0;
            }
            return ret;
        }

        public async Task<int> ChangePassword(string phone, CustomerModel customerModel)
        {
            int ret = 0;
            try
            {
                CustomerModel _cus = null;
                _cus = GetCustomerPhone(phone);

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
        public CustomerModel LoginCustomer(ViewLogin viewLogin)
        {
            var loginCus = _context.CustomerModels.Where(
                p => p.CustomerPhone.Equals(viewLogin.Phone)
                && p.CustomerPassword.Equals(_enCode.Encode(viewLogin.PassWord))
                ).FirstOrDefault();

            return loginCus;
        }

        public async Task<bool> CheckAmountGift(ViewSpin spin)
        {
            GiftModel gift = new GiftModel();
            gift = _context.GiftModels.Where(g => g.GiftId == spin.GiftId).FirstOrDefault();

            if (gift.GiftCount < 1)
            {
                return false;

            }
            else
            {
                return true;
            }
        }


        public async Task<bool> AddWinner(ViewSpin spin)
        {
            if (spin.GiftId > 0)
            {
                Random random = new Random();
                spin.Lucky = random.Next(1, 4);

                GiftModel gift = new GiftModel();
                gift = _context.GiftModels.Where(g => g.GiftId == spin.GiftId).FirstOrDefault();
                gift.GiftCount -= 1;
                gift.GiftUsed += 1;
                _context.Update(gift);
                await _context.SaveChangesAsync();
                WinnerModel winner = new WinnerModel();
                winner.WinnerCustommerId = spin.CustomerId;
                winner.WinnerName = gift.CustomerModel.CustomerName;
                winner.WinnerAddress = gift.CustomerModel.CustomerAddress;
                winner.WinnerPhone = gift.CustomerModel.CustomerPhone;
                winner.WinnerGift = spin.GiftId;
                if(spin.Lucky == 1)
                {
                    winner.WinnerProduct = gift.GiftProductName;
                }
                else
                {
                    winner.WinnerProduct = "Chúc bạn may mắn lần sau";
                }
                winner.WinnerDate = DateTime.Now;
                winner.WinnerStatus = false;
                await _context.AddAsync(winner);
                await _context.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> Spin(ViewSpin spin)
        {
            CustomerModel customer = new CustomerModel();
            customer = _context.CustomerModels.Where(c => c.CustomerID == spin.CustomerId).FirstOrDefault();
            if (customer.CustomerSpin < 1)
            {
                return false;
            }
            else
            {
                customer.CustomerSpin -= 1;
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<WinnerModel>> GetWinnerAll()
        {
            List<WinnerModel> list = new List<WinnerModel>();
            list = await _context.WinnerModels.OrderByDescending(w => w.WinnerDate).ToListAsync();
            return list;
        }

        public async Task<List<WinnerModel>> GetWinnerId(int id)
        {
            List<WinnerModel> list = new List<WinnerModel>();
            list = await _context.WinnerModels.Where(w => w.WinnerCustommerId == id).ToListAsync();
            return list;
        }

    }
}
