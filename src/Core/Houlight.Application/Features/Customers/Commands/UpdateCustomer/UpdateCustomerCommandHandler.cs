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
        _validator = validator;
    }

    public async Task<UpdateCustomerCommandResponse> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var customer = await _customerRepository.GetByIdAsync(request.Id);
        
        if (customer == null)
            throw new Exception("Müşteri bulunamadı.");

        // E-posta değişmişse kontrol et
        if (customer.Email != request.Email)
        {
            var existingCustomer = await _customerRepository.FirstOrDefaultAsync(x => 
                x.Email == request.Email && x.Id != request.Id);
            
            if (existingCustomer != null)
                throw new Exception("Bu e-posta adresi başka bir müşteri tarafından kullanılıyor.");
        }

        customer.Name = request.Name;
        customer.Surname = request.Surname;
        customer.Email = request.Email;
        customer.PhoneNumber = request.PhoneNumber;
        customer.UpdateDate = DateTime.Now;

        await _customerRepository.UpdateAsync(customer);

        return _mapper.Map<UpdateCustomerCommandResponse>(customer);
    }
} 