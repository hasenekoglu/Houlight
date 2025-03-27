using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class VehicleEntityConfiguration : BaseEntityTypeConfiguration<VehicleEntity>
{
    public override void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(name: "Vehicles");
        builder.Property(e => e.PlateNumber)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(e => e.Capacity)
            .IsRequired();

        builder.Property(e => e.IsAvailable)
            .IsRequired();


        builder.Property(e=>e.CurrentWeight)
            .IsRequired();

        builder.Property(e => e.CurrentVolume)
            .IsRequired();

        // VehicleEntity ile VehicleType arasında çoktan-çok ilişki
        builder.HasOne(e => e.VehicleTypeEntity)
            .WithMany(vt => vt.VehicleEntities)
            .HasForeignKey(e => e.VehicleTypeId);


        builder.HasOne(e => e.AssignedDriver)
            .WithMany()
            .HasForeignKey(e => e.AssignedDriverId);

        
  
    }
}