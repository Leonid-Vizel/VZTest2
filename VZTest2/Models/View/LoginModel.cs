using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.View
{
    public class LoginModel
    {
        [DisplayName("Логин")]
        [Required(ErrorMessage = "Укажите логин!")]
        public string Login { get; set; } = null!;
        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Укажите пароль!")]
        [MinLength(6, ErrorMessage = "Минимальный размер пароля - 6 символов!")]
        [DataType(DataType.Password, ErrorMessage = "Укажите пароль!")]
        public string Password { get; set; } = null!;
        public string? OldUrl { get; set; }
    }
}
