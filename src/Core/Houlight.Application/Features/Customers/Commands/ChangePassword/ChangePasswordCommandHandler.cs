using FluentValidation;
using Houlight.Application.Interfaces.Repositories;
using Houlight.Application.Services.Auth;
using MediatR;

namespace Houlight.Application.Features.Customers.Commands.ChangePassword;

public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ChangePasswordCommandValidator _validator;
    private readonly IAuthService _authService;

    public ChangePasswordCommandHandler(
        ICustomerRepository customerRepository,
        ChangePasswordCommandValidator validator,
        IAuthService authService)
    {
        _customerRepository = customerRepository;
        _validator = validator;
        _authService = authService;
    }

    public async Task<ChangePasswordCommandResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var customer = await _customerRepository.GetByIdAsync(request.Id);
        if (customer == null)
            throw new Exception("Müşteri bulunamadı.");

        // Mevcut şifreyi kontrol et
        if (!_authService.VerifyPasswordHash(request.CurrentPassword, customer.PasswordHash, customer.PasswordSalt))
            throw new Exception("Mevcut şifre yanlış.");

        // Yeni şifreyi hashle ve kaydet
        var (passwordHash, passwordSalt) = _authService.CreatePasswordHash(request.NewPassword);
        customer.PasswordHash = passwordHash;
        customer.PasswordSalt = passwordSalt;
        customer.UpdateDate = DateTime.Now;

        await _customerRepository.UpdateAsync(customer);

        return new ChangePasswordCommandResponse
        {
            Success = true,
            Message = "Şifre başarıyla değiştirildi."
        };
    }
} 