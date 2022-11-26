using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int ThemeId { get; set; }
        [Required(ErrorMessage = "Укажите название!")]
        [MinLength(3, ErrorMessage = "Минимальная длина названия - 3 символа!")]
        [MaxLength(100, ErrorMessage = "Максимальная длина названия - 100 символов!")]
        public string Title { get; set; }
        [MaxLength(500, ErrorMessage = "Максимальная длина описания - 500 символов!")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "Укажите тип вопроса!")]
        [Range(0, 6, ErrorMessage = "Укажите тип вопроса!")]
        public AnswerType AnswerType { get; set; }
        [Range(0,1000000, ErrorMessage = "Количество баллов за вопрос должно быть между 0 и 1000000")]
        public double CorrectBalls { get; set; }
        [MaxLength(2000, ErrorMessage = "Максимальная длина приавильного ответа - 2000 символов")]
        public string? CorrectText { get; set; }
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Укажите значение от -2147483647 до 2147483647!")]
        public int? CorrectInt { get; set; }
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Укажите корректное значение!")]
        public double? CorrectDouble { get; set; }
        public DateTime? CorrectDate { get; set; }
        public bool CheckRegister { get; set; } //Only for text

        public string? GetAnswerTypeName()
        {
            switch(AnswerType)
            {
                case AnswerType.Text:
                    return CheckRegister ? "Текстовый (С учётом регистра)" : "Текстовый (Без учёта регистра)";
                case AnswerType.Int:
                    return "Целочисленный";
                case AnswerType.Double:
                    return "Десятичная дробь";
                case AnswerType.Date:
                    return "Дата";
                case AnswerType.Radio:
                    return "Радио-кнопки";
                case AnswerType.Select:
                    return "Выпадающее меню";
                case AnswerType.Check:
                    return "Галочки";
                default:
                    return null;
            }
        }
    }

    public enum AnswerType
    {
        Text,
        Int,
        Double,
        Date,
        Radio,
        Select,
        Check
    }
}
