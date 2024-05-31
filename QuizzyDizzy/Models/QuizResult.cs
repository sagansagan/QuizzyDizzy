using QuizzyDizzy.Data;

namespace QuizzyDizzy.Models
{
    public class QuizResult
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Score { get; set; }
    }
}
