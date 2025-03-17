using AutoMapper;
using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly CreateCustomerCommandValidator _validator;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, CreateCustomerCommandValidator validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _validator=validator;
    }

    public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new CustomerEntity
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };

  
        await _customerRepository.AddAsync(customer);

        return _mapper.Map<CreateCustomerCommandResponse>(customer);
    }
} 