using FluentValidation;
using MyVaccine.WebApi.Dtos;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class AllergyDtoValidator : AbstractValidator<AllergyRequestDto>
    {
        public AllergyDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("El nombre es requerido.")
                .MaximumLength(255)
                .WithMessage("El nombre no puede tener más de 255 caracteres.");

            RuleFor(dto => dto.UserId)
                .NotEmpty()
                .WithMessage("El UserId es requerido.")
                .GreaterThan(0)
                .WithMessage("El UserId debe ser un número positivo.");

            RuleFor(dto => dto.AllergyId)
                 .NotEmpty()
                 .WithMessage("El UserId es requerido.")
                 .GreaterThan(0)
                 .WithMessage("El UserId debe ser un número positivo.");
        }
    }
}
