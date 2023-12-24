using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vb.Data.Entity;
using Vb.Data.Configurations.Common;

namespace Vb.Data.Configurations;
public class AccountTransactionConfiguration : BaseEntityConfiguration<AccountTransaction>
{

    public override void Configure(EntityTypeBuilder<AccountTransaction> builder)
    {
        // Apply base configuration
        base.Configure(builder);

        builder.Property(x => x.AccountId).IsRequired(true);
        builder.Property(x => x.TransactionDate).IsRequired(true);
        builder.Property(x => x.Amount).IsRequired(true).HasPrecision(18, 4);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(300);
        builder.Property(x => x.TransferType).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.ReferenceNumber).IsRequired(true).HasMaxLength(50);

        builder.HasIndex(x => x.ReferenceNumber);

    }
}