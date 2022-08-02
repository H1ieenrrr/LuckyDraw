using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    public class BarcodeModel
    {
        [Key]
        public int BarcodeId { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string BarcodeCode { get; set; }

        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        public string QRCode { get; set; }

        [Required(ErrorMessage = "Nhập số lượng"), Display(Name = "Code Count")]
        public int BarcodeCount { get; set; }

        [Display(Name = "Unilimited")]
        public bool BarcodeUnilimited { get; set; }

        [Display(Name = "Code Redemption Limit")]
        public int BarcodeRedemptionLimit { get; set; }


        [Required(ErrorMessage = "Chọn ngày "), Display(Name = "Spin Date")]
        [DataType(DataType.DateTime)]
        public DateTime BarcodeSpinDate { get; set; }


        [Required(ErrorMessage = "Chọn ngày  "), Display(Name = "Scanned Date")]
        [DataType(DataType.DateTime)]
        public DateTime BarcodeScannedDate { get; set; }

        public bool BarcodeScanned { get; set; }

        public bool BarcodeUseSpin { get; set; }
    }
}
