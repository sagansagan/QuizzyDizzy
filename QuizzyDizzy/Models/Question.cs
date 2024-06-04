using QuizzyDizzy.Shared;
namespace QuizzyDizzy.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? MediaUrl { get; set; }
        public bool IsVideo { get; set; } //false om bild
        public int TimeLimitSeconds { get; set; }
        public QuestionType QuestionType { get; set; }
        public ICollection<AnswerOption>? AnswerOptions { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
    }
}
