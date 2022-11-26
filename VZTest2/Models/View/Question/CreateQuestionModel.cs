using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using VZTest2.Models.Data;

namespace VZTest2.Models.View.Question
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
        [Required(ErrorMessage = "Укажите тип вопроса!")]
        [Range(0, 6, ErrorMessage = "Укажите тип вопроса!")]
        public AnswerType AnswerType { get; set; }
        [DisplayName("Баллов за правильный ответ")]
        [Range(0, 1000000, ErrorMessage = "Количество баллов за вопрос должно быть между 0 и 1000000")]
        public double CorrectBalls { get; set; }
        [DisplayName("Правильный ответ")]
        [MaxLength(2000, ErrorMessage = "Максимальная длина приавильного ответа - 2000 символов")]
        public string? CorrectText { get; set; }
        [DisplayName("Правильный ответ")]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Укажите значение от -2147483647 до 2147483647!")]
        public int? CorrectInt { get; set; }
        [DisplayName("Правильный ответ")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Укажите корректное значение!")]
        public double? CorrectDouble { get; set; }
        [DisplayName("Правильный ответ")]
        public DateTime? CorrectDate { get; set; }

        [DisplayName("Регистр текста")]
        public bool CheckRegister { get; set; }
        public List<Option> Options { get; set; } //For Radio, Select and Check
    }
}
