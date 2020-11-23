using FluentValidation;
using FluentValidationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace FluentValidationApp.FluentValidators
{
    public class DepartmentValidator:AbstractValidator<Department>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} field can not be blank";

        public DepartmentValidator()
        {
            RuleFor(x => x.CountEmployee).NotEmpty().WithMessage(NotEmptyMessage).GreaterThanOrEqualTo(30);
            RuleFor(x => x.DepartmentName).NotEmpty().WithMessage(NotEmptyMessage);
        }
    }
}
