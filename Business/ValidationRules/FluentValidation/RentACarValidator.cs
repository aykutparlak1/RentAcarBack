using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentACarValidator: AbstractValidator<Rental>
    {
        public RentACarValidator()
        { 
            RuleFor(x=>x.CarId).NotEmpty().WithMessage("Araba secilmelidir.");
            RuleFor(x=>x.RentDate).NotEmpty().WithMessage("Başlangıc Tarih secilmelidir.");
        }
    }
}
