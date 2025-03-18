using FluentValidation;

namespace Houlight.Application.Features.Vehicles.Commands.CreateVehicle;

public class CreateVehicleValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleValidator()
    {
        RuleFor(x => x.PlateNumber)
            .NotEmpty().WithMessage("Plaka numarası boş olamaz.")
            .Matches(@"^[0-9]{2}[A-Z]{1,3}[0-9]{2,4}$").WithMessage("Geçersiz plaka formatı.");

        //RuleFor(x => x.Brand)
        //    .NotEmpty().WithMessage("Marka boş olamaz.")
        //    .MaximumLength(50).WithMessage("Marka 50 karakterden uzun olamaz.");

        //RuleFor(x => x.Model)
        //    .NotEmpty().WithMessage("Model boş olamaz.")
        //    .MaximumLength(50).WithMessage("Model 50 karakterden uzun olamaz.");

        //RuleFor(x => x.Year)
        //    .NotEmpty().WithMessage("Yıl boş olamaz.")
        //    .GreaterThan(1900).WithMessage("Geçersiz yıl.")
        //    .LessThanOrEqualTo(DateTime.Now.Year + 1).WithMessage("Geçersiz yıl.");

        RuleFor(x => x.Capacity)
            .NotEmpty().WithMessage("Kapasite boş olamaz.")
            .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");

        RuleFor(x => x.VehicleTypeIds)
            .NotEmpty().WithMessage("Araç tipi ID boş olamaz.");

        RuleFor(x => x.LogisticsCompanyId)
            .NotEmpty().WithMessage("Lojistik şirketi ID boş olamaz.");
    }
} 