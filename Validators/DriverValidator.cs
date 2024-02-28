using f1api.DTOs;
using f1api.Models;
using FluentValidation;

namespace F1api.Validators
{
    public class DriverValidator : AbstractValidator<Driver>
    {
        public DriverValidator() { 
        RuleFor(x => x.Name ).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Nationality ).NotEmpty().WithMessage("Nationality is required");
        RuleFor(x => x.DateOfBirth ).NotEmpty().WithMessage("Date of Birth is required");
        RuleFor(x => x.CurrentTeam ).NotEmpty().WithMessage("Current Team is required");
        RuleFor(x => x.CarNumber).NotEmpty().WithMessage("Car Number  is required");

        }
       
    }
}
