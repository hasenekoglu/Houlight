using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class LoadEntityConfiguration : BaseEntityTypeConfiguration<LoadEntity>
{
    public override void Configure(EntityTypeBuilder<LoadEntity> builder)
    {
        base.Configure(builder);    

        builder.ToTable(name: "Loads");

        builder.Property(e => e.FromLocation)
            .IsRequired();

        builder.Property(e=>e.ToLocation)
            .IsRequired();

        builder.Property(e => e.LoadType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(e => e.Weight)
            .IsRequired();

        builder.Property(e => e.Volume)
            .IsRequired();

        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(e => e.DeliveryDate)
            .HasColumnType("datetime2");

        builder.Property(e => e.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(e => e.CustomerExpectedPrice)
            .HasColumnType("decimal(18,2)");

        builder.Property(e => e.CompanyOfferedPrice)
            .HasColumnType("decimal(18,2)");



        builder.HasOne(e => e.CustomerEntity)
            .WithMany(e => e.LoadEntities)
            .HasForeignKey(e => e.CustomerId);

        builder.HasOne(e => e.LogisticsCompanyEntity)
            .WithMany( )
            .HasForeignKey(e => e.LogisticsCompanyId);

        builder.HasOne(e => e.VehicleEntity)
            .WithMany() // Bir araç birden fazla yük taşıyabilir
            .HasForeignKey(e => e.AssignedVehicleId);
            //.OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.DriverEntity)
            .WithMany()  // Bir şoför birden fazla yük taşıyabilir
            .HasForeignKey(e => e.AssignedDriverId);
            //.OnDelete(DeleteBehavior.Restrict);


    }
}

