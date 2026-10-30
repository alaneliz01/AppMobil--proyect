using FluentValidation;
using ProgramasFacpya.Api.Features.Carreras.Dominio.Dto;

namespace ProgramasFacpya.Api.Features.Carreras;

public class CarrerasValidator : AbstractValidator<CarreraDTO>
{
    public CarrerasValidator()
    {
        RuleFor(x => x.Descripcion)
            .NotEmpty().WithMessage("La descripción es obligatoria")
            .MaximumLength(10).WithMessage("La descripción no puede exceder 10 caracteres");
    }
}
