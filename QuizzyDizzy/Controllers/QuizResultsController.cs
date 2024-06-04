using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzyDizzy.Data;
using QuizzyDizzy.Models;
using QuizzyDizzy.Shared.DTOs;
using System.Security.Claims;
using QuizzyDizzy.Shared.Enums;

namespace QuizzyDizzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizResultsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> SubmitQuiz([FromBody] QuizResultDto result)
        {
            if (result == null)
            {
                return BadRequest("Result data is null.");
            }

            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == result.QuizId);

            if (quiz == null)
            {
                return NotFound("Quiz not found.");
            }

            int score = 0;

            foreach (var answer in result.Answers)
            {
                var question = quiz.Questions.FirstOrDefault(q => q.Id == answer.QuestionId);
                if (question != null)
                {
                    if (question.QuestionType == QuestionType.FreeText)
                    {
                        var correctAnswer = question.AnswerOptions.FirstOrDefault()?.Text;
                        if (correctAnswer != null && correctAnswer.Equals(answer.Text, StringComparison.OrdinalIgnoreCase))//Skiftlägesokänslighet
                        {
                            score++;
                        }
                    }
                    else if (question.QuestionType == QuestionType.MultipleChoice)
                    {
                        var selectedOptions = answer.Text.Split(',').Select(int.Parse).ToList();
                        var correctOptions = question.AnswerOptions.Where(ao => ao.IsCorrect).Select(ao => ao.Id).ToList();

                        if (selectedOptions.Count == correctOptions.Count && !selectedOptions.Except(correctOptions).Any())
                        {
                            score++;
                        }
                    }
                }
            }

            var quizResult = new QuizResult
            {
                QuizId = result.QuizId,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Score = score,
            };

            _context.QuizResults.Add(quizResult);
            await _context.SaveChangesAsync();

            return Ok(score);
        }

    }
}
