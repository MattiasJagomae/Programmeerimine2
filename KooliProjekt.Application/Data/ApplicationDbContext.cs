using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KooliProjekt.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        internal DbSet<Asset> Assets { get; set; }
        internal DbSet<AssetClass> AssetClasses { get; set; }
        internal DbSet<AssetMonthly> AssetMonthlies { get; set; }
        internal DbSet<CashFlow> CashFlows { get; set; }
        internal DbSet<Portfolio> Portfolios { get; set; }
        internal DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Määra täpsus kõigile decimal tüüpi omadustele
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
        }
    }
}
