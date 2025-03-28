using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Persistence.Context;
using Houlight.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Houlight.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HoulightDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("SqlServer")));

        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<ILoadRepository, LoadRepository>();
        services.AddScoped<ILogisticsCompanyRepository, LogisticsCompanyRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
        services.AddScoped<ILoadOfferRepository, LoadOfferRepository>();

        return services;
    }
}

