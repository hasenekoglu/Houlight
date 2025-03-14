using Houlight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Houlight.Persistence.EntityConfigurations;

public class LogisticsCompanyEntityConfiguration : BaseEntityTypeConfiguration<LogisticsCompanyEntity>
{
    public override void Configure(EntityTypeBuilder<LogisticsCompanyEntity> builder)
    {
        base.Configure(builder);

        builder.ToTable(name: "LogisticsCompanies");
        builder.Property(e => e.CompanyName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.CompanyAddress)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(e => e.CompanyEmail)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(e => e.CompanyPhoneNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasMany(e => e.DriverEntities)
            .WithOne(d=> d.LogisticsCompanyEntity)
           .HasForeignKey(e => e.LogisticsCompanyId);

           builder.HasMany(e => e.VehicleEntities)
               .WithOne(d=> d.LogisticsCompanyEntity)
            .HasForeignKey(e => e.LogisticsCompanyId);

     
    }
}