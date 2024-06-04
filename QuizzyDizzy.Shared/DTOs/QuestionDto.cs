using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzyDizzy.Shared.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? MediaUrl { get; set; }
        public bool IsVideo { get; set; }
        public int TimeLimitSeconds { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<AnswerOptionDto> AnswerOptions { get; set; } = new List<AnswerOptionDto>();
        public int QuizId { get; set; }
    }
}
