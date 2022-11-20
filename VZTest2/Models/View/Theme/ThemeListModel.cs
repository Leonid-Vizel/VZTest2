namespace VZTest2.Models.View.Theme
{
    public class ThemeListModel : Data.Theme
    {
        public ThemeListModel(Data.Theme theme)
        {
            Id = theme.Id;
            Name = theme.Name;
            Description = theme.Description;
            Public = theme.Public;
            OwnerId = theme.OwnerId;
            CreateTime = theme.CreateTime;
            EditTime = theme.EditTime;
        }

        public ThemeListModel() { }
        public int QuestionCount { get; set; }
    }
}
