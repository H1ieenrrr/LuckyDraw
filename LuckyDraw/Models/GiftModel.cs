using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Gifts")]
    public class GiftModel
    {
        [Key]
        public int GiftId { get; set; }

        [Required, Display(Name = "Gift Code")]
        [Column(TypeName = "varchar(50)"), StringLength(50)]
        public string GiftCode { get; set; }

        [Display(Name = "Product Name")]
        [StringLength(100)]
        public string GiftProductName { get; set; }

        [Display(Name = "Description")]
        [StringLength(200)]
        public string GiftDescription { get; set; }

        [Required(ErrorMessage = "Nhập Gift code count"), Display(Name ="Gidt code count")]
        public int GiftCount { get; set; }

        [Display(Name = "Create Date")]
        [DataType(DataType.DateTime)]
        public DateTime GiftCreateDate { get; set; }

        [Display(Name = "Active")]
        public bool GiftActive { get; set; }

        [Display(Name = "Used")]
        public int GiftUsed { get; set; }

        [ForeignKey("CustomerModel")]
        public int GiftCustommer { get; set; }

        [ForeignKey("campaignModel")]
        public int GiftCampaign { get; set; }

        public bool IsDelete { get; set; }
        
        public CustomerModel CustomerModel { get; set; }
        public virtual  RuleModel ruleModel { get; set; }
        public virtual CampaignModel campaignModel { get; set; }
    }
}
