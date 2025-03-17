using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class BaseEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CreateDate)
            .ValueGeneratedOnAdd()
            .HasColumnType("datetime2");

        builder.Property(e => e.UpdateDate)
            .ValueGeneratedOnAdd()
            .HasColumnType("datetime2");

        builder.Property(e => e.DeleteDate)
            .ValueGeneratedOnAdd()
            .HasColumnType("datetime2");
    }
}

