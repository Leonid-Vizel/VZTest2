using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VZTest2.Models.Data;

namespace VZTest2.Models.View
{
    public class CreateQuestionModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100 символов!")]
        public string Title { get; set; }
        [DisplayName("Описание")]
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        [DisplayName("Тип вопроса")]
        public AnswerType AnswerType { get; set; }
        [DisplayName("Баллов за правильный ответ")]
        [Range(0, 1000000, ErrorMessage = "Количество баллов за вопрос должно быть между 0 и 1000000")]
        public double CorrectBalls { get; set; }
        [DisplayName("Учитывать регистр?")]
        public bool CheckRegister { get; set; } //Only for text
        public List<Option> Options { get; set; } //For Radio and Check
    }
}
