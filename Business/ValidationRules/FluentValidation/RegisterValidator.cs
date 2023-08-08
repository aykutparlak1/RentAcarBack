using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public RegisterValidator() 
        {
            RuleFor(r=>r.Email).NotEmpty().EmailAddress().WithMessage("'E-mail adresi geçerli bir e-mail adresi değil");
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz");
            RuleFor(r=>r.LastName).NotEmpty().WithMessage("Soyisim boş bırakılamaz");
            RuleFor(r=>r.Password).NotEmpty().MinimumLength(8).WithMessage("Şifre En az 8 karekter uzunluğunda olmalı.");
        }
    }
}
