using System.ComponentModel.DataAnnotations;
using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class OptionAnswer : IIndexable
    {
        [Key]
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int OptionId { get; set; }
    }
}
