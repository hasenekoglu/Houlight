using FluentValidation;

namespace Houlight.Application.Features.Vehicles.Commands.UpdateVehicle;

public class UpdateVehicleValidator : AbstractValidator<UpdateVehicleCommand>
{
    public UpdateVehicleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.PlateNumber)
            .NotEmpty().WithMessage("Plaka numarası boş olamaz.")
            .Matches(@"^[0-9]{2}[A-Z]{1,3}[0-9]{2,4}$").WithMessage("Geçersiz plaka formatı.");


        RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage("Kapasite boş olamaz.")
            .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");

        RuleFor(x => x.VehicleTypeIds)
            .NotEmpty().WithMessage("Araç tipi ID boş olamaz.");

        RuleFor(x => x.LogisticsCompanyId)
            .NotEmpty().WithMessage("Lojistik şirketi ID boş olamaz.");
    }
} 