using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VZTest2.Models.Data;

namespace VZTest2.Models.View
{
    public class CreateTestModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(80, ErrorMessage = "Максимальная длина названия - 80 символов!")]
        public string Name { get; set; }
        [DisplayName("Описание (необязательно)")]
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        [DisplayName("Пароль для прохождения тестирования (Если хотите закрыть от посторонних)")]
        [MaxLength(80, ErrorMessage = "Максимальная длина пароля - 50 символов!")]
        public string? Password { get; set; }
        [DisplayName("Публичный тест (отображается в открытый списках)")]
        [Required(ErrorMessage = "Укажите публичность теста!")]
        public bool Public { get; set; }
        [DisplayName("Максимальное количество попыток прохождения теста (необязательно)")]
        public int? MaxAttempts { get; set; }
        [DisplayName("Дата начала тестирования (необязательно)")]
        public DateTime? TestOpen { get; set; }
        [DisplayName("Дата конца тестирования (необязательно)")]
        public DateTime? TestClose { get; set; }
        [DisplayName("Конструктор теста")]
        public List<TestThemeBlock> Blocks { get; set; }
    }
}
