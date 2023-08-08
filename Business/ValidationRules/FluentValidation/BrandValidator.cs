using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator: AbstractValidator<Brand>
    {
        public BrandValidator() 
        {
            RuleFor(x => x.BrandName).NotEmpty().MinimumLength(2).WithMessage("Marka ismi en az 2 harfli olmalıdır.");
        }
    }
}
