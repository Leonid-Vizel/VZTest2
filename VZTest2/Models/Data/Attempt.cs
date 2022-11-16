using System.ComponentModel.DataAnnotations;
using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class Attempt : IIndexable
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
