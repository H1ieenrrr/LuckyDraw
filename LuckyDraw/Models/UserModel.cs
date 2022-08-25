using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Nhập Email"), Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Email Không Hợp Lệ")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Nhập Tên"), Display(Name = "Name")]
        [StringLength(100)]
        public string UserName { get; set; }

        [ForeignKey("roleModel")]
        public int UserRole { get; set; }

        [Required(ErrorMessage = "Nhập Số Điện Thoại")]
        [Column(TypeName = "varchar(15)"), MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})[-. ]?([0-9]{4})[-. ]?([0-9]{3})$", ErrorMessage = "Số Điện Thoại Không Hợp Lệ")]
        public string UserPhone { get; set; }

        [Required(ErrorMessage = "Nhập Địa Chỉ"), Display(Name = "Địa Chỉ")]
        [StringLength(200)]
        public string UserAddress { get; set; }

        [Required(ErrorMessage = "Nhập Mật Khẩu"), Display(Name = "Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Nhập Lại Mật Khẩu"), Display(Name = "Nhập Lại Mật Khẩu")]
        [Column(TypeName = "varchar(50)"), MaxLength(50)]
        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage = "Mật khẩu không khớp")]
        [NotMapped]
        public string UserCofirmPassword { get; set; }

        public bool IsDelete { get; set; }

        public RoleModel roleModel { get; set; }
    }
}
