using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Option
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Name { get; set; }
        public bool Correct { get; set; }
        [Range(-100, 100, ErrorMessage = "Значение процента должно быть не больше 100 и не меньше -100")]
        public short Percent { get; set; } //Only for check
    }
}
