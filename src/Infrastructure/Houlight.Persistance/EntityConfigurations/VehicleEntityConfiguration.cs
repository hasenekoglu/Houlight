using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class VehicleEntityConfiguration : BaseEntityTypeConfiguration<VehicleEntity, Guid>
{
    public override void Configure(EntityTypeBuilder<VehicleEntity> builder)
    {
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
        builder.HasMany(e => e.VehicleTypes)
            .WithMany(vt => vt.VehicleEntities)
            .UsingEntity(j => j.ToTable("VehicleEntityVehicleType")); // Bağlantı tablosu


        builder.HasOne(e => e.AssignedDriver)
            .WithMany()
            .HasForeignKey(e => e.AssignedDriverId);

        
        base.Configure(builder);
    }
}