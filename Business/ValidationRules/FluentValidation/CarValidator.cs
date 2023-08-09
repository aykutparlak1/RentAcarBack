using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty().WithMessage("Marka boş bırakılamaz");
            RuleFor(c => c.ColorId).NotEmpty().WithMessage("Renk boş bırakılamaz.");
            RuleFor(c => c.CarName).NotEmpty().MinimumLength(5).WithMessage("Araba ismi en az 5 harfli olmalıdır.");
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage("Model yılı boş bırakılamaz");
            RuleFor(c=>c.DailyPrice).NotEmpty().GreaterThan(99).WithMessage("Günlük fiyatı 100TL altında olamaz");
            RuleFor(c => c.PlateNumber).NotEmpty().WithMessage("Plaka numarası boş bırakılamaz");
            //.Must(Uniqe).WithMessage("Plaka numarasına sahip araba mevcut.");

        }
        //private bool Uniqe(string plateNumber)
        //{
        //    using (SqlContext context=new SqlContext())
        //    {
        //        var dbPlatte = context.Cars.Where(x=>x.PlateNumber.ToLower()==plateNumber.ToLower()).SingleOrDefault();
        //        if(dbPlatte==null)
        //            return true;
        //        return false;
                             
        //    }
        //}
    }
}
