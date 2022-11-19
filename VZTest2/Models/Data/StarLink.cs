namespace VZTest2.Models.Data
{
    public class StarLink
    {
        public Guid Id { get; set; }
        public StarLinkType StarLinkType { get; set; }
        public int UserId { get; set; }
        public int EntityId { get; set; }
    }

    public enum StarLinkType
    {
        Test,
        Theme,
        Question
    }
}
