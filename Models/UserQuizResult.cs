namespace Prepify.Models
{
    public class UserQuizResult
    {
        public int Id { get; set; }

        public string UserId { get; set; }


        public int Score { get; set; }

        public int total { get; set; }
        public DateTime AttemptedAt { get; set; }
    }
}
