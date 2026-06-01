using System.ComponentModel.DataAnnotations;

namespace Prepify.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Question> Question{ get; set; }
        public ICollection<Quiz> Quiz { get; set; }
    }
}
