using System.Collections.Generic;

namespace LuckyDraw.Models.ViewModel
{
    public class ViewSpin
    {
        public int CustomerId { get; set; }

        public int GiftId { get; set; }

        public int CampaignId { get; set; }
        public int Lucky { get; set; }

        public string GiftCode { get; set; }
        public GiftModel Listgift { get; set; } 
    }
}
