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

        [Display(Name = "Name")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        //[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email Không Hợp Lệ")]
        public string CustomerEmail { get; set; }

        //[Required(ErrorMessage = "Nhập Số Điện Thoại")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số Điện Thoại Không Hợp Lệ")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Địa Chỉ")]
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


        [Display(Name = "Block")]
        public bool CustomerBlock { get; set; }

        public int CustomerSpin { get; set; }

        [ForeignKey("roleModel")]
        public int Role { get; set; }

        //[Required(ErrorMessage = "Nhập Mật Khẩu"), Display(Name = "Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }

        //[Required(ErrorMessage = "Nhập Lại Mật Khẩu"), Display(Name = "Nhập Lại Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("CustomerPassword", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string CustomerCofirmPassword { get; set; }

       
        public bool IsDelete { get; set; }

   
         public RoleModel roleModel { get; set; }
    }
}
