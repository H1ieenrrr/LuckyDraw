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

        [ForeignKey("standalone")]
        public int CampaignStandalone { get; set; }
    }
}
