using FluentValidation;

namespace Houlight.Application.Features.Loads.Commands.LogisticsCompanyLoadUpdate;

public class LogisticsCompanyLoadUpdateValidator : AbstractValidator<LogisticsCompanyLoadUpdateCommand>
{
    public LogisticsCompanyLoadUpdateValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Yük ID boş olamaz");

        RuleFor(x => x.CompanyOfferedPrice)
            .GreaterThan(0).WithMessage("Teklif edilen fiyat 0'dan büyük olmalıdır");

        RuleFor(x => x.LogisticsCompanyId)
            .NotEmpty().WithMessage("Lojistik şirket ID boş olamaz");
    }
} 