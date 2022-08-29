using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Winner")]
    public class WinnerModel
    {
        [Key]
        public int WinnerId { get; set; }

        public int WinnerCustommerId { get; set; }

        public string WinnerName { get; set; }  
        public string WinnerAddress { get; set; }

        public string WinnerPhone { get; set; }

        [ForeignKey("gift")]
        public int WinnerGift { get; set; }

        public string WinnerProduct { get; set; }

        public DateTime WinnerDate { get; set; }

        public bool WinnerStatus { get; set; }

        public GiftModel gift { get; set; }
        
    }
}
