using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Attempt
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
