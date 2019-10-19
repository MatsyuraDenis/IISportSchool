using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.FluentValidators
{
    public class SectionValidator : AbstractValidator<Section>
    {
        IServiceRepository _repository;
        public SectionValidator(IServiceRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Веддіть назву");
            RuleFor(p => p.Name).Length(3, 255).WithMessage("Назва має бути від 3 до 255 символів");
            RuleFor(p => p.Name).Must(UniqueName).WithMessage("Дана секція вже існує");
        }

        private bool UniqueName(Section section, string name)
        {
            var dbSections = _repository.ListOfSections()
                                .Where(x => x.Name.ToLower() == name.ToLower())
                                .SingleOrDefault();

            if (dbSections == null)
                return true;

            return false;
        }
    }
}
