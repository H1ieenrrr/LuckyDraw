using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using LuckyDraw.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyDraw.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer _customerSvc;

        public CustomerController(ICustomer customerSvc)
        {
            _customerSvc = customerSvc;
        }

        [HttpPost]
        [ActionName("register")]
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
        [ActionName("changepass")]
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

        [HttpPut]
        [ActionName("spin")]
        public async Task<ActionResult> Spin([FromBody] ViewSpin spin)
        {
            bool amountSpin = await _customerSvc.Spin(spin);
            bool amountGift = await _customerSvc.CheckAmountGift(spin);
            bool addWin = await _customerSvc.AddWinner(spin);

            if (amountGift)
            {
                if (amountSpin)
                {
                    if (addWin)
                    {
                        if (spin.Lucky == 1)
                        {

                            return Ok("Quay thành công");
                        }
                        else
                        {
                            return Ok("Chúc bạn may mắn lần sau");
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                    
                }
                else
                {
                    return BadRequest("Quay thất bại, bạn hết lượt quay");
                }
            }
            else
            {
                return BadRequest("Số lượng gift code đã hết ");
            }
            
        }

        [HttpGet]
        [ActionName("winner")]
        public async Task<ActionResult<IEnumerable<WinnerModel>>> GetWinnerAll()
        {
            var list = await _customerSvc.GetWinnerAll();
            return list;
        }

        [HttpGet("{id}")]
        [ActionName("winnerid")]
        public async Task<List<WinnerModel>> GetWinnerId(int id)
        {
            var list = await _customerSvc.GetWinnerId(id);
            return list;
        }
    }
}
