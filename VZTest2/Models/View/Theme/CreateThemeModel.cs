using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.View.Theme
{
    public class CreateThemeModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100 символов!")]
        public string Name { get; set; }
        [DisplayName("Описание (необязательно)")]
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        [DisplayName("Публичность темы")]
        [Required(ErrorMessage = "Укажите публичность темы!")]
        public bool Public { get; set; }
    }
}
