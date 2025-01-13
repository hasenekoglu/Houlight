using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

    public class BaseEntityTypeConfiguration<TEntity,TId> : 
        IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

        builder.Property(e => e.CreatedDate)
                .HasColumnType("datetime2"); 
            
        builder.Property(e => e.UpdatedDate)
                .HasColumnType("datetime2");

        builder.Property(e => e.DeletedDate)
                .HasColumnType("datetime2");
        }
    }

