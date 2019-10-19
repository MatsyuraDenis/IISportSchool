using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models.FluentValidators
{
    public class GroupValidation : AbstractValidator<Group>
    {
        IGroupRepository _repository;
        ApplicationDbContext _context;
        public GroupValidation(IGroupRepository repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
            RuleFor(p => p.Name).Must(UniqueName).WithMessage("Група з такою назвою вже існує");
            RuleFor(p => p.MinChildAge).Must(ValidAge).WithMessage("Вік має бути в діапазоні від 3 до 27 років");
            RuleFor(p => p.MaxChildAge).Must(ValidAge).WithMessage("Вік має бути в діапазоні від 3 до 27 років");
            RuleFor(p => p.MinChildAge).Must(ValidAge0).WithMessage("Мінімальний вік не може бути більшим за максимальний");
            RuleFor(p => p.MaxChildAge).Must(ValidAge0).WithMessage("Мінімальний вік не може бути більшим за максимальний");
            RuleFor(p => p.PricePerMonth).Must(ValidPrice).WithMessage("Ціна не може бути менше ніж 0");
        }

        private bool ValidPrice(int price)
        {
            if (price < 0)
                return false;
            return true;
        }

        private bool UniqueName(Group group, string name)
        {
            var dbGroup = _repository.Groups
                                .Where(x => x.Name.ToLower() == name.ToLower())
                                .SingleOrDefault();

            if (dbGroup == null)
                return true;

            return false;
        }

        private bool ValidAge(Group group, int age)
        {
            if (age < 3 || age >= 27)
                return false;

            return true;
        }
        private bool ValidAge0(Group group, int age)
        {

            if (group.MinChildAge > group.MaxChildAge)
                return false;

            return true;
        }
    }


}
