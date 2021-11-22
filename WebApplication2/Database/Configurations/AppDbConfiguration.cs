using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Database.Entities;

namespace WebApplication2.Database.Configurations
{
    public class AppDbConfiguration
    {


        public class TransactionsConfiguration : IEntityTypeConfiguration<TransactionEntity>
        {
            public void Configure(EntityTypeBuilder<TransactionEntity> builder)
            {

                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).IsRequired();
                builder.Property(x => x.BeneficiaryName).IsRequired();

                builder.Property(x => x.Direction).HasConversion<string>().HasMaxLength(1).IsRequired();

                builder.Property(x => x.Amount).IsRequired();
                builder.Property(x => x.Description);

                builder.Property(x => x.Currency).HasConversion<string>()
                                             .HasMaxLength(3)
                                             .IsRequired();


                builder.Property(x => x.Kind).HasConversion<string>()
                             .IsRequired();

                builder.Property(x => x.CategoryCode);

                



            }
        }
        public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
        {
            public void Configure(EntityTypeBuilder<CategoryEntity> builder)
            {
                builder.HasKey(x => x.Code);
                builder.Property(x => x.Code).IsRequired();
                builder.Property(x => x.ParentCode);
                builder.Property(x => x.Name).IsRequired();

            }
        }

        public class SplitsConfiguration : IEntityTypeConfiguration<SplitTransactionEntity>
        {
            public void Configure(EntityTypeBuilder<SplitTransactionEntity> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Amount).IsRequired();
                builder.Property(x => x.CategoryCode).IsRequired();

                builder.HasOne(x => x.Transaction)
                .WithMany(b => b.Splits)
                .HasForeignKey(x => x.TransactionId)
                .OnDelete(DeleteBehavior.Cascade);

                

            }
        }


    }
}
