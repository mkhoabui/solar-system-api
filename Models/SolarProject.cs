using System.ComponentModel.DataAnnotations;

namespace final.Models
{
    public class SolarProject
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cost { get; set; }
        public string DueDate { get; set; }
    }
}