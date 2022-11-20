namespace VZTest2.Models.View.Theme
{
    public class EditThemeModel : CreateThemeModel
    {
        public int Id { get; set; }

        public EditThemeModel(Data.Theme theme)
        {
            Id = theme.Id;
            Name = theme.Name;
            Description = theme.Description;
            Public = theme.Public;
        }

        public EditThemeModel() { }
    }
}
