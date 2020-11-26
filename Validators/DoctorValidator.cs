using DoctorManagement.Models;
using FluentValidation;

namespace DoctorManagement.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotEqual(l => l.LastName).Length(3, 12).Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.LastName).NotNull().NotEqual(l => l.FirstName).Length(3, 12).Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.HudumaNumber).NotNull();
        }
    }
}
