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
    public class GiftController : ControllerBase
    {
        private readonly IGift _giftSvc;

        public GiftController(IGift giftSvc)
        {
            _giftSvc = giftSvc;
        }

        [HttpPost]
        public async Task<ActionResult<int>> AddGift(GiftModel gift)
        {
            try
            {
                int id = await _giftSvc.AddGift(gift);
                gift.GiftId = id;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(1);
        }
    }
}
