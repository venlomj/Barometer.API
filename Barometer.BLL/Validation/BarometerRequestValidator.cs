using Barometer.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.BLL.Validation
{
    public class BarometerRequestValidator : AbstractValidator<BarometerRequest>
    {
        public BarometerRequestValidator()
        {
            RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required");

            RuleFor(x => x.EmployeeCount)
                .NotEmpty().WithMessage("EmployeeCount is required")
                .GreaterThan(0).WithMessage("EmployeeCount must be greater than 0");
        }
    }
}
