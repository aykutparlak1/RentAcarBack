using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentACarValidatör: AbstractValidator<Rental>
    {
        public RentACarValidatör()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x=>x.CarId).NotEmpty();
            RuleFor(x=>x.RentDate).NotEmpty();
        }
    }
}
