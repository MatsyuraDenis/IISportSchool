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
    }


}
