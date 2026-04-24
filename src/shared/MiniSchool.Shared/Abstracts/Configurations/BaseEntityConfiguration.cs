using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniSchool.Shared.Abstracts.Entities;
using MiniSchool.Shared.Interfaces.Entities;

namespace MiniSchool.Shared.Abstracts.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class, IEntity, new()
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Id);

        // MS-SQL-də GUID default olaraq 'NEWID()' və ya 'NEWSEQUENTIALID()' ola bilər
        builder.Property(p => p.Id)
            .HasColumnName("id")
            .UseIdentityColumn()
            .HasColumnOrder(0)
            ;

    }

}

