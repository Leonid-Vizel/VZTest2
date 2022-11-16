using System.ComponentModel.DataAnnotations;

namespace VZTest2.Models.Data
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string BackColor { get; set; }
        public string ForeColor { get; set; }
    }
}
