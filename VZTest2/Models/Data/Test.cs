using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class Test : IIndexable, ICreatable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool Public { get; set; }
        public string? PasswordHash { get; set; }
        public int? MaxAttempts { get; set; }
        public DateTime? TestOpen { get; set; }
        public DateTime? TestClose { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
    }
}
