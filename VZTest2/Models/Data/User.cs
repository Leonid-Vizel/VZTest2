using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class User : IIndexable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public bool AllowCreateTest { get; set; }
        public bool AllowCreateTheme { get; set; }
        public string PasswordHash { get; set; }
    }
}
