using FluentValidation;
using ProgramasFacpya.Api.Features.Maestros.Dominio.Dto;

namespace ProgramasFacpya.Api.Features.Maestros;

public class MaestrosValidator : AbstractValidator<MaestroDTO>
{
    public MaestrosValidator()
    {
        RuleFor(x => x.Nombre)
            .NotEmpty().WithMessage("El nombre es obligatorio")
            .MaximumLength(50).WithMessage("El nombre no puede exceder 50 caracteres");

        RuleFor(x => x.APaterno)
            .NotEmpty().WithMessage("El apellido paterno es obligatorio")
            .MaximumLength(80).WithMessage("El apellido paterno no puede exceder 80 caracteres");

        RuleFor(x => x.AMaterno)
            .NotEmpty().WithMessage("El apellido materno es obligatorio")
            .MaximumLength(80).WithMessage("El apellido materno no puede exceder 80 caracteres");
    }
}
