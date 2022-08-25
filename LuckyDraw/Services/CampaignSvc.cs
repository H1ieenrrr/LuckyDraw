using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuckyDraw.Services
{
    public class CampaignSvc : ICampaign
    {
        protected DataContext _context;
        public CampaignSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CampaignModel>> GetAllCampaign()
        {
            List<CampaignModel> list = new List<CampaignModel>();
            list = await _context.CampaignModels.ToListAsync();
            return list;
        } 
    }
}
