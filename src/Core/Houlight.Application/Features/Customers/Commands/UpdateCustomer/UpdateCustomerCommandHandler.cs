using AutoMapper;
using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly UpdateCustomerCommandValidator _validator;

    public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper, UpdateCustomerCommandValidator validator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _validator=validator;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        
        if (customer == null)
            throw new Exception("Müşteri bulunamadı.");

        customer.Name = request.Name;
        customer.Surname = request.Surname;
        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;

        await _customerRepository.UpdateAsync(customer);


        return _mapper.Map<UpdateCustomerCommandResponse>(customer);
    }
} 