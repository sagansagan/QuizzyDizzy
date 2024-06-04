using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizzyDizzy.Components.Pages;
using QuizzyDizzy.Data;
using QuizzyDizzy.Models;
using QuizzyDizzy.Shared.DTOs;
using System.Security.Claims;

namespace QuizzyDizzy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context) 
        { 
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetAllQuizzes()
        {
            var quizzes = await _context.Quizzes.Select(x => new QuizDto { Title = x.Title }).ToListAsync();
            return Ok(quizzes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<QuizDto>>> GetQuizById(int id)
        {
            var quiz = await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.AnswerOptions)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (quiz == null) 
            {
                return NotFound("quiz not found");
            }

            return Ok(quiz);
        }

        [HttpGet("userquizzes")]
        public async Task<IEnumerable<QuizDto>> GetUserQuizzes()
        {

            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            var userQuizzes = _context.Quizzes
                .Where(u => u.CreatedByUserId == userId)
                .Select(q => new QuizDto { Title = q.Title })
                .ToList();

            return userQuizzes;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<QuizDto>>> DeleteQuizById(int id)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            _context.Remove(quiz);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<QuizDto>>> EditQuizById(int id, QuizDto editedQuiz)
        {
            var quiz = await _context.Quizzes.FindAsync(id);
            if (quiz == null)
            {
                return NotFound("quiz not found");
            }

            quiz.Title = editedQuiz.Title;

            await _context.SaveChangesAsync();

            return Ok(quiz);
        }

        [HttpPost("new")]
        [Authorize]
        public async Task<ActionResult<QuizDto>> CreateQuiz([FromBody] QuizDto quiz) 
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var newQuiz = new Quiz
            {
                Title = quiz.Title,
                CreatedByUserId = userId,
                Questions = quiz.Questions.Select(q => new Question
                {
                    Text = q.Text,
                    MediaUrl = q.MediaUrl,
                    IsVideo = q.IsVideo,
                    TimeLimitSeconds = q.TimeLimitSeconds,
                    QuestionType = q.QuestionType,
                    AnswerOptions = q.AnswerOptions.Select(ao => new AnswerOption
                    {
                        Text = ao.Text,
                        IsCorrect = ao.IsCorrect
                    }).ToList()
                }).ToList()
            };

            _context.Quizzes.Add(newQuiz);
            await _context.SaveChangesAsync();

            quiz.Id = newQuiz.Id;
            return CreatedAtAction(nameof(GetQuizById), new { id = quiz.Id }, quiz);
        }
    }
}
