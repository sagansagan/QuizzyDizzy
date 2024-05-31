using QuizzyDizzy.Data;

namespace QuizzyDizzy.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<Question> Questions { get; set; }
        public string CreatedByUserId { get; set; }
        public ApplicationUser CreatedByUser { get; set; }
    }
}
