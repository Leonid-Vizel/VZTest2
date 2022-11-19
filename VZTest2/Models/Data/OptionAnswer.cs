using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class OptionAnswer
    {
        [Key]
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int OptionId { get; set; }
    }
}
