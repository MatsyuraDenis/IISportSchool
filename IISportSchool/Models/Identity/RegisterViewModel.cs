using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажіть почту")]
        [EmailAddress(ErrorMessage = "Ведіть коректну почту")]
        [Display(Name = "E-mail(почта)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ведіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердити пароль")]
        [Compare("Password", ErrorMessage = "Пароль і його підтвердження не співпадають")]
        public string ConfirmPassword { get; set; }
    }
}
