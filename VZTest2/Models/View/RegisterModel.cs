using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace VZTest2.Models.View
{
    public class RegisterModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Укажите логин!")]
        public string Login { get; set; } = null!;
        [DisplayName("Никнейм")]
        [Required(ErrorMessage = "Укажите никнейм!")]
        [MinLength(3, ErrorMessage = "Минимальный размер пароля - 3 символа!")]
        public string Name { get; set; } = null!;
        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Укажите пароль!")]
        [MinLength(6, ErrorMessage = "Минимальный размер пароля - 6 символов!")]
        [DataType(DataType.Password, ErrorMessage = "Укажите пароль!")]
        public string Password { get; set; } = null!;
    }
}
