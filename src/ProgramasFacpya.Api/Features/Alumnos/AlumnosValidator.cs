using FluentValidation;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

namespace ProgramasFacpya.Api.Features.Alumnos;

public class AlumnosValidator : AbstractValidator<AlumnoDTO>
{
    public AlumnosValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es requerido"); // <-- Revisa que tenga ';' al final
        RuleFor(x => x.APaterno).NotEmpty();
        RuleFor(x => x.AMaterno).NotEmpty();
        RuleFor(x => x.IdCarrera).GreaterThan((byte)0);
    }
}