using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.FluentValidators
{
    public class ChildrenValidator : AbstractValidator<AddChildViewModel>
    {
        public ChildrenValidator()
        {
            RuleFor(r => r.Children.Age).Must(InGroupAgesScope).WithMessage("Неправильний вік");
            RuleFor(r => r.Children.Name).NotNull().WithMessage("Ім'я не може бути пустим");
            RuleFor(r => r.Children.Name).Length(2, 25).WithMessage("Ім'я має мати від 2 до 25 символів");
            RuleFor(r => r.Children.SecondName).NotNull().WithMessage("Фамілія не може бути пустим");
            RuleFor(r => r.Children.SecondName).Length(2, 25).WithMessage("Фамілія має мати від 2 до 25 символі");
        }

        private bool InGroupAgesScope(AddChildViewModel viewModel, int age)
        {
            if (age < viewModel.MinAge || age > viewModel.MaxAge)
                return false;

            return true;
        }
    }
}
