using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.FluentValidators
{
    public class DepartmentValidator : AbstractValidator<Department>
    {
        IServiceRepository _repository;
        public DepartmentValidator(IServiceRepository repository)
        {
            _repository = repository;
            RuleFor(p => p.Name).NotEmpty().WithMessage("Веддіть назву");
            RuleFor(p => p.Name).Length(3, 255).WithMessage("Назва має бути від 3 до 255 символів");
            RuleFor(p => p.Name).Must(UniqueName).WithMessage("Даний відділ вже існує");
        }

        private bool UniqueName(string name)
        {
            var dbDepartment = _repository.Departments
                                .Where(x => x.Name.ToLower() == name.ToLower())
                                .SingleOrDefault();

            if (dbDepartment == null)
                return true;

            return false;
        }
    }
}
