using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team2_5.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; } //required
        public string TaskName { get; set; } //required
        public string? DueDate { get; set; }
        public int Quadrant { get; set; } //required

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool Completed { get; set; }
    }
}
