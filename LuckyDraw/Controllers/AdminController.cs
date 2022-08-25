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
    public class AdminController : ControllerBase
    {
        private readonly ICustomer _customerSvc;

        public AdminController(ICustomer customerSvc)
        {
            _customerSvc = customerSvc;
        }

        [HttpPut("{email}")]
        public async Task<ActionResult<int>> ChangePassword(string email, CustomerModel customer)
        {
            if (email != customer.CustomerEmail)
            {
                return BadRequest();
            }
            try
            {
                await _customerSvc.ChangePasswordAdmin(email, customer);
                customer.CustomerEmail = email;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }
    }
}
