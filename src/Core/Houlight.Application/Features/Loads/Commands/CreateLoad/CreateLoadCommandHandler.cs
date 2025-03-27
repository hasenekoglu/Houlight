using AutoMapper;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Domain.Entities;
using MediatR;

namespace Houlight.Application.Features.Loads.Commands.CreateLoad;

public class CreateLoadCommandHandler : IRequestHandler<CreateLoadCommand, CreateLoadResponse>
{
    private readonly ILoadRepository _loadRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateLoadCommandHandler(IMapper mapper, ICustomerRepository customerRepository, ILoadRepository loadRepository)
    {
        _customerRepository=customerRepository;
        _loadRepository=loadRepository;
        _mapper=mapper;
    }

    public async Task<CreateLoadResponse> Handle(CreateLoadCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
        if (customer == null)
            throw new Exception("Müşteri bulunamadı");

        var load = _mapper.Map<LoadEntity>(request);
        load.Status = Domain.Enums.LoadStatus.Pending;

        await _loadRepository.AddAsync(load);

        var response = _mapper.Map<CreateLoadResponse>(load);
        return response;
    }
} 