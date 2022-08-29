using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Rules")]
    public class RuleModel
    {
        [Key]
        public int RuleId { get; set; }

        [Required(ErrorMessage = "Nhập Rule Name"), Display(Name = "Rule Name")]
        [StringLength(50)]
        public string RuleName { get; set; }

        //[Required(ErrorMessage = "Chọn Gift"), Display(Name = "Select Gift")]
        [StringLength(50)]
        public string RuleSelectGift { get; set; }

        [Required(ErrorMessage = "Nhập số lượng"), Display(Name = "Amount")]
        public int RuleAmount { get; set; }

        
        [Required(ErrorMessage = "Chọn thời gian bắt đầu"), Display(Name = "Start time")]
        [DataType(DataType.Time)]
        public DateTime RuleStartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime RuleEndTime { get; set; }

        [Display(Name = "All Day")]
        public bool RuleAllDay { get; set; }

        [Display(Name = "Probability")]
        public int RuleProbability { get; set; }

        [Display(Name = "Monthly on day")]
        [DataType(DataType.Date)]
        public DateTime RuleMonthly { get; set; }

        [Display(Name = "Weekly on")]
        [DataType(DataType.Date)]
        public DateTime RuleWeekly { get; set; }

        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        public DateTime RuleStartDay { get; set; }

        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        public DateTime RuleEndDay { get; set; }

        [ForeignKey("giftModel")]
        public int RuleGiftId { get; set; }

        public virtual  GiftModel giftModel { get; set; }
    }
}
