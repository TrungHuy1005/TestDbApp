using Microsoft.EntityFrameworkCore;
using TestDbApp.Models;

namespace TestDbApp.Conext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<CashFlow> CashFlowEntity { get; set; }
    }
}
