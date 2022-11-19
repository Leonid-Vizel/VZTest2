using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100 символов!")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        public bool Public { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; } 
    }
}
