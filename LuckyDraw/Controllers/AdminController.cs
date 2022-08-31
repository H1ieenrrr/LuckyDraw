using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyDraw.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _adminSvc;
      

        public AdminController(IAdmin adminSvc, ICustomer customer)
        {
            _adminSvc = adminSvc;
            
        }

        [HttpPut("{email}")]
        [ActionName("ChangePass")]
        public async Task<ActionResult<int>> ChangePassword(string email, CustomerModel customer)
        {
            if (email != customer.CustomerEmail)
            {
                return BadRequest();
            }
            try
            {
                await _adminSvc.ChangePasswordAdmin(email, customer);
                customer.CustomerEmail = email;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }

        [HttpGet]
        [ActionName("listCustomer")]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomer()
        {
            var list = await _adminSvc.GetCustomerAll();
            return list;
        }

        [HttpGet]
        [ActionName("campaign")]
        public async Task<ActionResult<IEnumerable<CampaignModel>>> GetCampaign()
        {
            var list = await _adminSvc.GetAllCampaign();
            return list;
        }

        [HttpPost]
        [ActionName("campaign")]
        public async Task<ActionResult<int>> AddCampaign(CampaignModel campaign)
        {
            try
            {

                int id = await _adminSvc.AddCampaign(campaign);
                campaign.CampaignId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpGet]
        [ActionName("rule")]
        public async Task<ActionResult<IEnumerable<RuleModel>>> GetRuleAll()
        {
            var list = await _adminSvc.GetAllRule();
            return list;
        }

        [HttpPost]
        [ActionName("rule")]
        public async Task<ActionResult> AddRule(RuleModel rule)
        {
            try
            {
                int id = await _adminSvc.AddRule(rule);
                rule.RuleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }

        [HttpPut("{id}")]
        [ActionName("rule")]
        public async Task<ActionResult> UpdateRule(int id, RuleModel rule)
        {
            if (id != rule.RuleId)
            {
                return BadRequest();
            }
            try
            {
                await _adminSvc.EditRule(id, rule);
                rule.RuleId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }

        [HttpDelete("{id}")]
        [ActionName("rule")]
        public async Task<ActionResult<int>> DeleteRule(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteRule(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        [HttpGet]
        [ActionName("gift")]
        public async Task<ActionResult<IEnumerable<GiftModel>>> GetGift()
        {
            var list = await _adminSvc.GetGiftAll();
            return list;
        }

        [HttpPost]
        [ActionName("gift")]
        public async Task<ActionResult<int>> AddGift(GiftModel gift)
        {
            try
            {
                int id = await _adminSvc.AddGift(gift);
                gift.GiftId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }


        [HttpPut("{id}")]
        [ActionName("gift")]
        public async Task<ActionResult<int>> EditGift(int id, GiftModel gift)
        {
            if (id != gift.GiftId)
            {
                return BadRequest();
            }
            try
            {
                await _adminSvc.EditGift(id, gift);
                gift.GiftId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }
            return Ok(1);
        }

        [HttpDelete("{id}")]
        [ActionName("gift")]
        public async Task<ActionResult<int>> DeleteGift(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _adminSvc.DeleteGift(id);

            }
            catch (Exception ex)
            {
                return BadRequest(-1);
            }

            return Ok(1);
        }

        [HttpGet]
        [ActionName("barcode")]
        public async Task<ActionResult<IEnumerable<BarcodeModel>>> GetBarcode()
        {
            var list = await _adminSvc.GetBarcode();
            return list;
        }


        [HttpPost]
        [ActionName("barcode")]
        public async Task<ActionResult<int>> AddBarcode(BarcodeModel barcode)
        {
            try
            {
                int id = await _adminSvc.AddBarcode(barcode);
                barcode.BarcodeId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }


        [HttpGet]
        [ActionName("barcodehistory")]
        public async Task<ActionResult<IEnumerable<BarcodeHistory>>> GetBarcodeHistory()
        {
            var list = await _adminSvc.GetBarcodeHistory();
            return list;
        }

        [HttpPost]
        [ActionName("scanbarcode")]
        public async Task<ActionResult<int>> ScanBarcode(BarcodeHistory barcodeHistory)
        {
            try
            {
                int id = await _adminSvc.ScanBarcode(barcodeHistory);
                barcodeHistory.BarcodeHistoryId = id;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
    }
}
