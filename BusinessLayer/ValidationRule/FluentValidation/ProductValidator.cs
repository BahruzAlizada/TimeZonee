using EntityLayer.Concrete;
using FluentValidation;
using System;


namespace BusinessLayer.ValidationRule.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Bu xana boş keçilə bilməz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Qiymət Sıfırdan böyük olmalıdır");
        }
    }
}
