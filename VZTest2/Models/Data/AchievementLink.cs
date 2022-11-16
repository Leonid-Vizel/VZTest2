using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class AchievementLink
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AchievementId { get; set; }
    }
}
