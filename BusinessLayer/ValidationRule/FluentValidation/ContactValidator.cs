using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRule.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email boş ola bilməz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Emaili düzgün daxil edin");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mətn başlığı boş buraxıla bilməz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş buraxıla bilməz");
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad boş buraxıla bilməz");
        }
    }
}
