using FluentValidation;
using FluentValidationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidationApp.FluentValidators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} field can not be blank";
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage).Must(x => {
                return ! x.ToLower().StartsWith('ğ');
            }).WithMessage("Name field can not start Ğ");

            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("The format is not suitable");

            RuleFor(x => x.Surname).NotEmpty().WithMessage(NotEmptyMessage).NotEqual(x => x.Name).WithMessage("Surname can not equal to Name field");

            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(0, 110).WithMessage("Age can not be greater 110");

            RuleFor(x => x.CreditCardNumber).CreditCard().WithMessage("The format is not suitable");

            RuleFor(x => x.Gender).IsInEnum().WithMessage("Please use only 1 or 2");

            RuleForEach(x => x.Departments).SetValidator(new DepartmentValidator());

        }
    }
}
