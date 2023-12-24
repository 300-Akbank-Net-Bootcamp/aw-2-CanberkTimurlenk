using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Vb.Data.Entity;
using Vb.Data.Configurations.Common;

namespace Vb.Data.Configurations;

public class ContactConfiguration : BaseEntityConfiguration<Contact>
{
    public override void Configure(EntityTypeBuilder<Contact> builder)
    {
        // Apply base configuration
        base.Configure(builder);

        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.ContactType).IsRequired(true).HasMaxLength(10);
        builder.Property(x => x.Information).IsRequired(true).HasMaxLength(100);
        builder.Property(x => x.IsDefault).IsRequired(true).HasDefaultValue(false);

        builder.HasIndex(x => x.CustomerId);
        builder.HasIndex(x => new { x.Information, x.ContactType }).IsUnique(true);

    }
}