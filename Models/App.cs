using System.ComponentModel.DataAnnotations;

namespace VolgaIT2022App5.Models
{
    public class App
    {
        public int owner { get; set; } = -1;
        public int Id { get; set; }
        public string Identity { get; set; } = "";
        public DateTime DateCreated { get; set; } = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc);
        [Required(ErrorMessage = "Не указано название")]
        public string Name { get; set; } = "";
        [Required(ErrorMessage = "Не указано название")]
        public string Desc { get; set; } = "";
    }
}
