using FluentValidation;

namespace Houlight.Application.Features.VehicleTypes.Commands.UpdateVehicleType;

public class UpdateVehicleTypeValidator : AbstractValidator<UpdateVehicleTypeCommand>
{
    public UpdateVehicleTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Type)
            .NotEmpty().WithMessage("Araç tipi boş olamaz.")
            .MaximumLength(50).WithMessage("Araç tipi 50 karakterden uzun olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama 500 karakterden uzun olamaz.");
    }
} 