using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Houlight.Application.Features.Customers.Queries.GetCustomersByFilter;

public class GetCustomersByFilterQueryHandler : IRequestHandler<GetCustomersByFilterQuery, List<GetCustomersByFilterResponse>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomersByFilterQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<List<GetCustomersByFilterResponse>> Handle(GetCustomersByFilterQuery request, CancellationToken cancellationToken)
    {
        var query = _customerRepository.AsQueryable();

        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            var searchTerm = request.SearchTerm.ToLower();
            query = query.Where(x => 
                x.Name.ToLower().Contains(searchTerm) || 
                x.Surname.ToLower().Contains(searchTerm));
        }

        if (!string.IsNullOrEmpty(request.Email))
        {
            query = query.Where(x => x.Email.ToLower().Contains(request.Email.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.PhoneNumber))
        {
            query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));
        }

        var customers = await query.ToListAsync(cancellationToken);
        return _mapper.Map<List<GetCustomersByFilterResponse>>(customers);
    }
} 