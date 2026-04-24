using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Shared.Abstracts.Configurations;

public abstract class BaseActiveEntityConfiguration<T>
    : BaseEntityConfiguration<T>
    where T : class, IActiveEntity, new()
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.IsArchived)
            .HasColumnName("is_archived")
            .HasDefaultValue(0) 
            .IsRequired()
            .HasColumnOrder(2);

        builder.HasQueryFilter(p => !p.IsArchived);
    }
}

