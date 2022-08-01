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
    }
}
