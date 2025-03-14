using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class DriverEntityConfiguration : BaseEntityTypeConfiguration<DriverEntity> 
{
    public override void Configure(EntityTypeBuilder<DriverEntity> builder)
    {

        base.Configure(builder);

        builder.ToTable(name: "Drivers");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Surname)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.LicenseNumber)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.PhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(e => e.DriverStatus)
            .HasConversion<string>();

        
;
    }
}