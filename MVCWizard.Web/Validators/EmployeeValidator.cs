using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MVCWizard.Web.Models;

namespace FluentValidationConsole.Models
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(emp => emp.FullName).NotNull().NotEqual("") ;
            RuleFor(x => x.Salary).InclusiveBetween(1000,10000);
        }
    }
}
