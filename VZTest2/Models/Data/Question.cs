using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class Question : IIndexable
    {
        public int Id { get; set; }
        public Guid ThemeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AnswerType AnswerType { get; set; }
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
