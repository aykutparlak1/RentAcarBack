using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentACarValidator: AbstractValidator<Rental>
    {
        public RentACarValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x=>x.CarId).NotEmpty();
            RuleFor(x=>x.RentDate).NotEmpty();
        }
    }
}
