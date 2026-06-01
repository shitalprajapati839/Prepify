namespace Prepify.Models
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public string Title { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<QuizQuestion> QuizQuestions { get; set; }

    }
}
