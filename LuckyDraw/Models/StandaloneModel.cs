using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuckyDraw.Models
{
    [Table("Standalone")]
    public class StandaloneModel
    {
        [Key]
        public int StandaloneId { get; set; }
        [Display(Name = "Campaing name")]
        public string StandaloneCampaignName { get; set; }
        public bool StandaloneApplyAll { get; set; }
    }
}
