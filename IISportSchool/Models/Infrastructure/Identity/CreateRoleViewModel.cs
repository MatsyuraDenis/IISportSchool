using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class CreateRoleViewModel
    {
        [Required(ErrorMessage = "Ведіть назву")]
        [Display(Name = "Назва ролі")]
        public string RoleName { get; set; }
    }
}
