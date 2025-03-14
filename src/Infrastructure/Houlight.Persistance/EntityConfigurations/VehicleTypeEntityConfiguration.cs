using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class VehicleTypeEntityConfiguration : BaseEntityTypeConfiguration<VehicleTypeEntity>
{
    public override void Configure(EntityTypeBuilder<VehicleTypeEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable("VehicleTypes");

        builder.Property(e => e.Type)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(100);

       
    }
}