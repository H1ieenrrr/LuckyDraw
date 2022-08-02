using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<CampaignModel> CampaignModels { get; set; }
        public DbSet<BulkModel> BulkModels { get; set; }
        public DbSet<StandaloneModel> StandaloneModels { get; set; }
        public DbSet<GiftModel> GiftModels { get; set; }
        public DbSet<RuleModel> RuleModels { get; set; }

        public DbSet<CustomerModel> CustomerModels { get; set; }

        public DbSet<BarcodeModel> BarcodeModels { get; set; }
    }
}
