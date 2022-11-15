namespace VZTest2.Interfaces
{
    public interface ICreatable
    {
        public int OwnerId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? EditTime { get; set; }
    }
}
