using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vb.Data.Configurations.Common;
using Vb.Data.Entity;

namespace Vb.Data.Configurations;
public class EftTransactionConfiguration : BaseEntityConfiguration<EftTransaction>
{
    public override void Configure(EntityTypeBuilder<EftTransaction> builder)
    {
        // Apply base configuration
        base.Configure(builder);

        builder.Property(x => x.AccountId).IsRequired(true);
        builder.Property(x => x.TransactionDate).IsRequired(true);
        builder.Property(x => x.Amount).IsRequired(true).HasPrecision(18, 4);
        builder.Property(x => x.Description).IsRequired(false).HasMaxLength(300);
        builder.Property(x => x.ReferenceNumber).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.SenderAccount).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.SenderIban).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.SenderName).IsRequired(true).HasMaxLength(50);

        builder.HasIndex(x => x.ReferenceNumber);

    }
}