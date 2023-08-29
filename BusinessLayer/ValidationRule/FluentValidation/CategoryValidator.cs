using EntityLayer.Concrete;
using FluentValidation;
using System;

namespace BusinessLayer.ValidationRule.FluentValidation
{
    internal class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
