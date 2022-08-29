using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Barcode")]
    public class BarcodeModel
    {
        [Key]
        public int BarcodeId { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string BarcodeCode { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string QRCode { get; set; }

        [Required(ErrorMessage = "Chọn ngày ")]
        [DataType(DataType.DateTime)]
        public DateTime BarcodeCreateDate { get; set; }

        [Required(ErrorMessage = "Chọn ngày ")]
        [DataType(DataType.DateTime)]
        public DateTime BarcodeExpiredDate { get; set; }

        [Required(ErrorMessage = "Nhập số lượng"), Display(Name = "Code Count")]
        public int BarcodeCount { get; set; }

        public int BarcodeCharset { get; set; }

        public int BarcodeCodeLength { get; set; }

        [Display(Name = "Unilimited")]
        public bool BarcodeUnilimited { get; set; }

        [Display(Name = "Code Redemption Limit")]
        public int BarcodeRedemptionLimit { get; set; }


        [Required(ErrorMessage = "Chọn ngày  "), Display(Name = "Scanned Date")]
        [DataType(DataType.DateTime)]
        public DateTime BarcodeScannedDate { get; set; }


        [ForeignKey("Campaign")]
        public int CampaignId { get; set; }
        public bool BarcodeScanned { get; set; }

        public bool BarcodeActive { get; set; }

        public CampaignModel Campaign { get; set; }
    }
}
