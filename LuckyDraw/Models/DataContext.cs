using Microsoft.EntityFrameworkCore;

namespace LuckyDraw.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GiftModel>()
                .HasOne(a => a.ruleModel)
                .WithOne(a => a.giftModel)
                .HasForeignKey<RuleModel>(c => c.RuleId);
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<RoleModel> RoleModels { get; set; }
        public DbSet<CampaignModel> CampaignModels { get; set; }
        public DbSet<GiftModel> GiftModels { get; set; }
        public DbSet<RuleModel> RuleModels { get; set; }

        public DbSet<CustomerModel> CustomerModels { get; set; }
        public DbSet<WinnerModel> WinnerModels { get; set; }
        public DbSet<BarcodeModel> BarcodeModels { get; set; }
    }
}
