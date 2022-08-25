using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LuckyDraw.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerSvc;

        public CustomerController(ICustomer customerSvc)
        {
            _customerSvc = customerSvc;
        }

        [HttpPost]
        public async Task<ActionResult<int>> RegisterCustomer(CustomerModel customer)
        {
            try
            {
                int id = await _customerSvc.RegisterCustomer(customer);
                customer.CustomerID = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPut("{phone}")]
        public async Task<ActionResult<int>> ChangePassword(string phone, CustomerModel customer)
        {
            if(phone != customer.CustomerPhone)
            {
                return BadRequest();
            }
            try
            {
                await _customerSvc.ChangePassword(phone, customer);
                customer.CustomerPhone = phone;
            }
            catch(Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
