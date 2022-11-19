using System.ComponentModel.DataAnnotations;
using VZTest2.Interfaces;

namespace VZTest2.Models.Data
{
    public class Option : IIndexable
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int Index { get; set; }
        public string Name { get; set; }
        [Range(-100, 100, ErrorMessage = "Значение процента должно быть не больше 100 и не меньше -100")]
        public short Percent { get; set; } //Only for check
    }
}
