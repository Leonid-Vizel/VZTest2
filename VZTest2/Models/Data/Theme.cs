using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Theme
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Public { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; } 
    }
}
