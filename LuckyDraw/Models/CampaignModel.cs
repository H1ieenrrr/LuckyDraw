﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Campaigns")]
    public class CampaignModel
    {
        [Key]
        public int CampaignId { get; set; }

        [ForeignKey("bulkModel")]
        public int CampaignBulk { get; set; }

        [ForeignKey("standaloneModel")]
        public int CampaignStandalone { get; set; }

        [Display(Name = "Description")]
        [StringLength(200)]
        public string CampaignDescription { get; set; }

        [Display(Name = "Code Usage Limit ")]
        public int CampaignUsageLimit { get; set; }

        [Display(Name = "Unlimited")]
        public bool CampaignUnlimited { get; set; }

        [Display(Name = "Charset")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string CampaignCharset { get; set; }

        [Display(Name = "Code Length")]
        public int CampaignLength { get; set; }

        [Display(Name = "Prefix")]
        [Column(TypeName = "varchar(10)"), MaxLength(10)]
        public string CampaignPrefix { get; set; }

        [Display(Name = "Postfix")]
        [StringLength(50)]
        public string CampaignPostfix { get; set; }

        [Required(ErrorMessage = "Chọn ngày bắt đầu"),Display(Name = "Start Date")]
        [DataType(DataType.DateTime)]
        public DateTime CampaignStarDate { get; set; }

        [Required(ErrorMessage = "Chọn ngày kết thúc"), Display(Name = "End Date")]
        [DataType(DataType.DateTime)]
        public DateTime CampaignEndDate { get; set; }

        [StringLength(100)]
        public string CampaignNote { get; set; }

        [ForeignKey("giftModel")]
        public int CampaignGift { get; set; }

        [ForeignKey("userModel")]
        public int CampaignOwner { get; set; }

        [ForeignKey("barcodeModel")]
        public int CampaignBarcode { get; set; }

        
        public UserModel userModel { get; set; }
        public BulkModel bulkModel { get; set; }
        public StandaloneModel standaloneModel { get; set; }
        public GiftModel giftModel { get; set; }
        public BarcodeModel barcodeModel { get; set; }


    }
}
