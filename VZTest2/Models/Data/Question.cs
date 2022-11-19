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
        public AnswerType AnswerType { get; set; }
        [Range(0,1000000, ErrorMessage = "Количество баллов за вопрос должно быть между 0 и 1000000")]
        public double CorrectBalls { get; set; }
        public bool CheckRegister { get; set; } //Only for text
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
