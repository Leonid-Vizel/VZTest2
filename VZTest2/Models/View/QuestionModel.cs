using System.ComponentModel.DataAnnotations;
using VZTest2.Models.Data;

namespace VZTest2.Models.View
{
    public class QuestionModel : Question
    {
        public QuestionModel(Question question)
        {
            Id = question.Id;
            ThemeId = question.ThemeId;
            Title = question.Title;
            Description = question.Description;
            AnswerType = question.AnswerType;
            CorrectBalls = question.CorrectBalls;
            CheckRegister = question.CheckRegister;
        }
        public List<Option>? Options { get; set; }
    }
}
