using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Winner")]
    public class WinnerModel
    {
        [Key]
        public int WinnerCustommerId { get; set; }

        [ForeignKey("gift")]
        public int WinnerGift { get; set; }

        public DateTime WinnerDate { get; set; }

        public bool WinnerStatus { get; set; }

        public GiftModel gift { get; set; }
    }
}
