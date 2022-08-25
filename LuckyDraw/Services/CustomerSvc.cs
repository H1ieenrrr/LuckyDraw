using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using System;
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
        public CustomerModel GetCustomerEmail(string email)
        {
            CustomerModel customer = null;
            customer = _context.CustomerModels.FirstOrDefault(m => m.CustomerEmail == email);
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
            catch(Exception ex)
            {
                ret = 0;
            }
            return ret;
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
            catch(Exception ex)
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

        public CustomerModel LoginAdmin(ViewLogin viewLogin)
        {
            var loginAdmin = _context.CustomerModels.Where(
                p => p.CustomerEmail.Equals(viewLogin.Email)
                && p.CustomerPassword.Equals(_enCode.Encode(viewLogin.PassWord))
                ).FirstOrDefault();

            return loginAdmin;
        }
    }
}
