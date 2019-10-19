using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IISportSchool.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Ведіть почту")]
        [EmailAddress(ErrorMessage = "Ведіть коректну почту")]
        [Display(Name = "E-mail(почта)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ведіть пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнити мене!")]        
        public bool RememberMe { get; set; }
    }
}
