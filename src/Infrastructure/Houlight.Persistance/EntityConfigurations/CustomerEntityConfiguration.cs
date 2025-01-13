using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class CustomerEntityConfiguration : BaseEntityTypeConfiguration<CustomerEntity,Guid> 
{
    public override void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable(name: "Customers");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Surname)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);
        
        base.Configure(builder);

    }
}