using Houlight.Application.Interfaces.Repositories;
using MediatR;

namespace Houlight.Application.Features.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id);
        
        if (customer == null)
            throw new Exception("Müşteri bulunamadı.");

        // Soft delete için DeleteAsync metodunu kullanıyoruz
        var result = await _customerRepository.DeleteAsync(customer);
        return result > 0;
    }
} 