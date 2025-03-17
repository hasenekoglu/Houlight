using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Houlight.Application;
public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();
        
        services.AddMediatR(assm);
        services.AddAutoMapper(assm);
        services.AddValidatorsFromAssembly(assm);
        services.AddFluentValidationAutoValidation();
        return services;


    }
}
