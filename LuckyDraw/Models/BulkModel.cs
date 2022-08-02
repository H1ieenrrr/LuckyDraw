using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Bulk")]
    public class BulkModel
    {
        [Key]
        public int BulkId { get; set; }

        [Required(ErrorMessage = "Nhập Program Name"), Display(Name = "Program Name")]
        [StringLength(50)]
        public string BulkProgramName { get; set; }

        [Required(ErrorMessage = "Nhập code count"),Display(Name = "Code Count")]
        public int BulkCount { get; set; }

        [Display(Name = "Auto Update")]
        public bool BulkAutoUpdate { get; set; }
        public bool BulkOnly { get; set; }
    }
}
