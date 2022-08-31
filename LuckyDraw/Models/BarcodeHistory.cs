using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("BarcodeHistory")]
    public class BarcodeHistory
    {
        [Key]
        public int BarcodeHistoryId { get; set; }

        [ForeignKey("customerModel")]
        public int BarcodeCustomer { get; set; }

        [ForeignKey("barcodeModel")]
        public int BarcodeId { get; set; }
        public string Code { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BarcodeHistotyCreateDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BarcodeHistotyScannedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BarcodeHistotySpinDate { get; set; }

        public string BarcodeHistoryOwner { get; set; }

        public bool BarcodeHistoryScanned { get; set; }

        public bool BarcodeHistoryUsespin { get; set; }

        public BarcodeModel barcodeModel { get; set; }

        public CustomerModel customerModel { get; set; }
    }
}
