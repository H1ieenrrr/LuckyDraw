using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Customers")]
    public class CustomerModel
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Nhập họ tên"), Display(Name = "Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Nhập Số Điện Thoại")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số Điện Thoại Không Hợp Lệ")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Nhập Địa Chỉ"), Display(Name = "Địa Chỉ")]
        [StringLength(200)]
        public string CustomerAddress { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime CustomerBirtday { get; set; }

        [Display(Name = "Chức vụ")]
        [StringLength(30)]
        public string CustomerPosition { get; set; }

        [Display(Name = "Loại hình kinh doanh")]
        [StringLength(30)]
        public string CustomerTypeBusinees { get; set; }

        [Display(Name = "Win Date")]
        [DataType(DataType.Date)]
        public DateTime CustomerWinDate { get; set; }

        [Display(Name = "Block")]
        public bool CustomerBlock { get; set; }

        [Display(Name = "Sent Gift")]
        public bool CustomerSentGift { get; set; }

        [Required(ErrorMessage = "Nhập Mật Khẩu"), Display(Name = "Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

        [Required(ErrorMessage = "Nhập Lại Mật Khẩu"), Display(Name = "Nhập Lại Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Mật khẩu không khớp")]
        public string CustomerCofirmPassword { get; set; }

        [ForeignKey("giftModel")]
        public int CustomerGiftCode { get; set; }
        public bool IsDelete { get; set; }

        public GiftModel giftModel { get; set; }

    }
}
