using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.View.Theme
{
    public class ThemeModel : Data.Theme
    {
        public ThemeModel(Data.Theme theme)
        {
            Id = theme.Id;
            Name = theme.Name;
            Description = theme.Description;
            Public = theme.Public;
            OwnerId = theme.OwnerId;
            CreateTime = theme.CreateTime;
            EditTime = theme.EditTime;
        }
        public List<QuestionModel> Questions { get; set; }
        public bool Self { get; set; }
    }
}
