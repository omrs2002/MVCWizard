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
            RuleFor(emp => emp.Dept).NotEmpty();
            
            ///RuleFor(customer => customer.CustomerDiscount).GreaterThan(0).When(customer => customer.IsPreferredCustomer);
            RuleFor(emp => emp.Salary).GreaterThanOrEqualTo(3500).When(emp=> emp.Gender == 2).WithMessage("Female Salary must be > 3500");


        }
    }
}
