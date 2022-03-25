using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace VolgaIT2022App5.Models
{
    public class User
    {
        public User()
        {
        }
        //public User(string Email = "", string Password = "")
        //{
        //    this.Email = Email;
        //    this.Password = Password;
        //}
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }="";
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }="";
    }
}
