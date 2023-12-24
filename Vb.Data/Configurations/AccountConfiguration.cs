using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vb.Data.Configurations.Common;
using Vb.Data.Entity;

namespace Vb.Data.Configurations;
public class AccountConfiguration : BaseEntityConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> builder)
    {
        // Apply base configuration
        base.Configure(builder);

        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.AccountNumber).IsRequired(true);
        builder.Property(x => x.IBAN).IsRequired(true).HasMaxLength(34);
        builder.Property(x => x.Balance).IsRequired(true).HasPrecision(18, 4);
        builder.Property(x => x.CurrencyType).IsRequired(true).HasMaxLength(3);
        builder.Property(x => x.Name).IsRequired(false).HasMaxLength(100);
        builder.Property(x => x.OpenDate).IsRequired(true);

        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => x.AccountNumber).IsUnique(true);

        builder.HasMany(x => x.AccountTransactions)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(true);

        builder.HasMany(x => x.EftTransactions)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(true);

    }
}