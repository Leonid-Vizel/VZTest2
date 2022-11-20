using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VZTest2.Models.View.Theme;

namespace VZTest2.Models.Data
{
    public class Theme
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public Theme(CreateThemeModel model)
        {
            Name = model.Name;
            Description = model.Description;
            Public = model.Public;
            CreateTime = DateTime.Now;
        }

        public Theme() { }
    }
}
