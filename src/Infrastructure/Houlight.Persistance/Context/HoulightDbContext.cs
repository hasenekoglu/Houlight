using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Houlight.Domain.Entities;
using Houlight.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Houlight.Persistence.Context;

public class HoulightDbContext : DbContext
{
    private IConfiguration Configuration { get; set; }
   
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<DriverEntity> Drivers { get; set; }
    public DbSet<LogisticsCompanyEntity> LogisticsCompanies { get; set; }
    public DbSet<VehicleEntity> Vehicles { get; set; }
    public DbSet<VehicleTypeEntity> VehicleTypes { get; set; }
    public DbSet<LoadEntity> Loads { get; set; }
    public DbSet<LoadOfferEntity> LoadOffers { get; set; }

    public HoulightDbContext(DbContextOptions dbContextOptions, IConfiguration configuration): base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            base.OnConfiguring(
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlServer")));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(i => i.State == EntityState.Added)
            .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntities(addedEntities);
    }

    private void PrepareAddedEntities(IEnumerable<Domain.Entities.BaseEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.CreateDate == DateTime.MinValue)
                entity.CreateDate = DateTime.Now;
        }
    }

}

