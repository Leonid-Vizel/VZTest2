using System.ComponentModel.DataAnnotations;
using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class Test : IIndexable, ICreatable
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(80, ErrorMessage = "Максимальная длина названия - 80 символов!")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        public int OwnerId { get; set; }
        public bool Public { get; set; }
        public string? PasswordHash { get; set; }
        public int? MaxAttempts { get; set; }
        public DateTime? TestOpen { get; set; }
        public DateTime? TestClose { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
    }
}
