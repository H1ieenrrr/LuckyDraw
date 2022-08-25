using LuckyDraw.Interfaces;
using LuckyDraw.Models;
using System;
using System.Threading.Tasks;

namespace LuckyDraw.Services
{
    public class GiftSvc : IGift
    {
        protected DataContext _context;
        public GiftSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<int> AddGift(GiftModel giftModel)
        {
            int ret = 0;
            try
            {
                giftModel.IsDelete = true;

                _context.Add(giftModel);
                _context.SaveChanges();
                ret = giftModel.GiftId;
            }
            catch(Exception ex)
            {
                ret = 0;
            }
            return ret;
        }
    }
}
