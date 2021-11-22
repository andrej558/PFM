using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.Database.Entities;
using WebApplication2.Models;

namespace WebApplication2.Database
{
    public class AppDbContext: DbContext
    {



        public AppDbContext(DbContextOptions options) : base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuration.GetConnectionString("AppDb");

            optionsBuilder.UseSqlServer(connectionString);
        }


        public DbSet<MccCodesEntity> MccCodes { get; set; }

        public DbSet<TransactionEntity> Transactions { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<SplitTransactionEntity> Splits { get; set; }

    }
}
