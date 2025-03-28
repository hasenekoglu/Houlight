using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class LoadOfferEntityConfiguration : BaseEntityTypeConfiguration<LoadOfferEntity>
{
    public override void Configure(EntityTypeBuilder<LoadOfferEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(name: "LoadOffers");

        builder.Property(x => x.FromLocation)
            .IsRequired();

        builder.Property(x => x.ToLocation)
            .IsRequired();

        builder.Property(x => x.LoadType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(x => x.Weight)
            .IsRequired();

        builder.Property(x => x.Volume)
            .IsRequired();

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(x => x.DeliveryDate)
            .HasColumnType("datetime2");

        builder.Property(x => x.CustomerExpectedPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(x => x.CompanyOfferedPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.HasOne(x => x.LoadEntity)
            .WithMany(x => x.LoadOffers)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CustomerEntity)
            .WithMany()
            .HasForeignKey(x => x.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LogisticsCompanyEntity)
            .WithMany()
            .HasForeignKey(x => x.LogisticsCompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.VehicleEntity)
            .WithMany()
            .HasForeignKey(x => x.AssignedVehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DriverEntity)
            .WithMany()
            .HasForeignKey(x => x.AssignedDriverId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 