using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator() 
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Boş Bırakılamaz.").MaximumLength(10).WithMessage("Min:10 karakter");
        }
    }
}
