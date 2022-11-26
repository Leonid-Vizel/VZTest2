using VZTest2.Models.Data;

namespace VZTest2.Models.View.Question
{
    public class QuestionModel : Data.Question
    {
        public QuestionModel(Data.Question question)
        {
            Id = question.Id;
            ThemeId = question.ThemeId;
            Title = question.Title;
            Description = question.Description;
            AnswerType = question.AnswerType;
            CorrectBalls = question.CorrectBalls;
            CheckRegister = question.CheckRegister;
        }
        public QuestionModel() { }
        public List<Option>? Options { get; set; }
    }
}
