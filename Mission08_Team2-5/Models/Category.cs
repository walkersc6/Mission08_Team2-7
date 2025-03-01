using System.ComponentModel.DataAnnotations;

namespace Mission08_Team2_5.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryId { get; set; } //required
        
        [Display(Name = "Category Name")]
        public string? CategoryName { get; set; } // required
    }
}
