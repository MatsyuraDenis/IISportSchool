using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IISportSchool.Models;

namespace IISportSchool.Models.FluentValidators
{
    public class TeacherViewModelValidator : AbstractValidator<TeacherViewModel>
    {
        public TeacherViewModelValidator()
        {
            RuleFor(t => t.Name).NotNull().WithMessage("Ведіть Ім'я");
            RuleFor(t => t.SecondName).NotNull().WithMessage("Ведіть Фамілію");
            RuleFor(t => t.Name).Length(2, 25).WithMessage("Ім'я менше 2 або більше 25 символів");
            RuleFor(t => t.SecondName).Length(2, 25).WithMessage("Фамілія менше 2 або більше 25 символів");

            RuleFor(t => t.Salary).Must(MoreThanZero).WithMessage("Менше ніж 0");
            RuleFor(t => t.YearsOfExperience).Must(MoreThanZero).WithMessage("Менше ніж 0");
            RuleFor(t => t.Photo).NotNull().WithMessage("Виьеріть фото");
        }

        private bool MoreThanZero(int arg)
        {
            return arg >= 0;
        }
    }
    public class UpdateTeacherViewModelValidator : AbstractValidator<UpdateteacherViewModel>
    {
        public UpdateTeacherViewModelValidator()
        {
            RuleFor(t => t.Name).NotNull().WithMessage("Ведіть Ім'я");
            RuleFor(t => t.SecondName).NotNull().WithMessage("Ведіть Фамілію");
            RuleFor(t => t.Name).Length(2, 25).WithMessage("Ім'я менше 2 або більше 25 символів");
            RuleFor(t => t.SecondName).Length(2, 25).WithMessage("Фамілія менше 2 або більше 25 символів");

            RuleFor(t => t.Salary).Must(MoreThanZero).WithMessage("Менше ніж 0");
            RuleFor(t => t.YearsOfExperience).Must(MoreThanZero).WithMessage("Менше ніж 0");
            RuleFor(t => t.Photo).NotNull().WithMessage("Виьеріть фото");
        }

        private bool MoreThanZero(int arg)
        {
            return arg >= 0;
        }
    }
}
