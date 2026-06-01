using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Prepify.Models
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }
        [Required]

        public string Title { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string Answer { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]  

        public Category Category { get; set; }
        [ValidateNever]

        public ICollection<QuizQuestion> QuizQuestions { get; set; }

    }
}
