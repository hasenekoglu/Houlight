using AutoMapper;
using Houlight.Application.Features.Customers.Commands.CreateCustomer;
using Houlight.Application.Features.Customers.Commands.UpdateCustomer;
using Houlight.Application.Features.Customers.Commands.Login;
using Houlight.Application.Features.Customers.Queries.GetAllCustomers;
using Houlight.Application.Features.Customers.Queries.GetCustomerById;
using Houlight.Application.Features.Customers.Queries.GetCustomersByFilter;
using Houlight.Domain.Entities;

namespace Houlight.Application.Mapping;

public class CustomerMappingProfile : Profile
{
    public CustomerMappingProfile()
    {
        CreateMap<CustomerEntity, CreateCustomerCommandResponse>();
        CreateMap<CustomerEntity, UpdateCustomerCommandResponse>();
        CreateMap<CustomerEntity, GetCustomerByIdResponse>();
        CreateMap<CustomerEntity, GetAllCustomersResponse>();
        CreateMap<CustomerEntity, GetCustomersByFilterResponse>();
        CreateMap<CustomerEntity, LoginCustomerResponse>();
    }
} 