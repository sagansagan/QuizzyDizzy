using Microsoft.AspNetCore.Identity;
using QuizzyDizzy.Models;

namespace QuizzyDizzy.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        //public ICollection<Quiz> CreatedQuizzes { get; set; }
        //public ICollection<QuizResult> QuizResults { get; set; }
    }

}
