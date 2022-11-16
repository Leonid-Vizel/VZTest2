using VZTest2.Instruments;
using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class User : IIndexable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public bool AllowCreate { get; set; }
        public bool Admin { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisterTime { get; set; }

        public void WriteToSession(ISession session)
        {
            session.SetInt32("id", Id);
            session.SetString("login", Login);
            session.SetString("name", Name);
            session.SetBoolean("create", AllowCreate);
            session.SetBoolean("admin", Admin);
        }

        public void UpdateSessionData(ISession session)
        {
            session.SetString("name", Name);
        }
    }
}
