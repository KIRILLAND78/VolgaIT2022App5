using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VolgaIT2022App5.Models
{
    public class RegUser : User
    {
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string ConPassword { get; set; } = "";
    }
}
