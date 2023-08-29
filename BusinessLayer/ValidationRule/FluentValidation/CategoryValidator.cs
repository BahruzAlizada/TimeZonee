using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRule.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
