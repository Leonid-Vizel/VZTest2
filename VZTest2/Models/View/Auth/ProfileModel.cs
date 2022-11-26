using VZTest2.Models.Data;

namespace VZTest2.Models.View.Auth
{
    public class ProfileModel
    {
        public User User { get; set; }
        public List<Achievement> Achievements { get; set; }
        public bool Self { get; set; }
        public int TestCreateCount { get; set; }
        public int QuizCreateCount { get; set; }
        public int ThemeCreateCount { get; set; }
        public int QuestionCreateCount { get; set; }
        public int TestAttemptCount { get; set; }
        public int QuizAttemptCount { get; set; }
    }
}
