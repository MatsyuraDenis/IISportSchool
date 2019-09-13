using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.FluentValidators
{
    public class SectionValidator : AbstractValidator<Section>
    {
        public SectionValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Веддіть назву");
            RuleFor(p => p.Name).Length(3, 255).WithMessage("Назва має бути від 3 до 255 символів");
        }
    }
}
