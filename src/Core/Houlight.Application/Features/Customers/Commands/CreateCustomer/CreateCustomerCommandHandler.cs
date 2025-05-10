using AutoMapper;
using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Application.Services.Auth;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly CreateCustomerCommandValidator _validator;
    private readonly IAuthService _authService;

    public CreateCustomerCommandHandler(
        ICustomerRepository customerRepository, 
        IMapper mapper, 
        CreateCustomerCommandValidator validator,
        IAuthService authService)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _validator = validator;
        _authService = authService;
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

        // Şifre hash'leme işlemi
        var (passwordHash, passwordSalt) = _authService.CreatePasswordHash(request.Password);
        customer.PasswordHash = passwordHash;
        customer.PasswordSalt = passwordSalt;

        await _customerRepository.AddAsync(customer);

        return _mapper.Map<CreateCustomerCommandResponse>(customer);
    }
} 