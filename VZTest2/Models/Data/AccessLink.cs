using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class AccessLink
    {
        [Key]
        public Guid Id { get; set; }
        public AccessLinkType Type { get; set; }
        public int UserId { get; set; }
        public int EntityId { get; set; }
    }

    public enum AccessLinkType
    {
        Test,
        Theme
    }
}
