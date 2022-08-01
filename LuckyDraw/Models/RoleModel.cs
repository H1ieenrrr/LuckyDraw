using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Roles")]
    public class RoleModel
    {
        [Key]
        public int RoleId { get; set; }

        [StringLength(20)]
        public string RoleName { get; set; }
    }
}
