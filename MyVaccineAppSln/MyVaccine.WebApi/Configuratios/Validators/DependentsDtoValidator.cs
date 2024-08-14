using FluentValidation;
using MyVaccine.WebApi.Dtos.Dependent;

namespace MyVaccine.WebApi.Configurations.Validators
{
    public class DependentsDtoValidator : AbstractValidator<DependentRequestDto>
    {
        public DependentsDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .WithMessage("El nombre es requerido.")
                .MaximumLength(255)
                .WithMessage("El nombre no puede tener más de 255 caracteres.");

            RuleFor(dto => dto.DateOfBirth)
                .NotEmpty()
                .WithMessage("La fecha de nacimiento es requerida.")
                .LessThan(DateTime.Now)
                .WithMessage("'Date Of Birth' debe ser menor que la fecha actual.");

            RuleFor(dto => dto.UserId)
                .NotEmpty()
                .WithMessage("El UserId es requerido.")
                .GreaterThan(0)
                .WithMessage("El UserId debe ser un número positivo.");
        }
    }
}
