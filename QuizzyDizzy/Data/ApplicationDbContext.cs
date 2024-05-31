using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizzyDizzy.Models;

namespace QuizzyDizzy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOption> AnswerOptions { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfigurerar enum som string
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionType)
                .HasConversion<string>();

            modelBuilder.Entity<Quiz>()
                .HasMany(q => q.Questions)
                .WithOne(q => q.Quiz)
                .HasForeignKey(q => q.QuizId)
                .OnDelete(DeleteBehavior.Cascade); // Specify no action on delete to prevent cycles


            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerOptions)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<QuizResult>()
                .HasOne(qr => qr.Quiz)
                .WithMany()
                .HasForeignKey(qr => qr.QuizId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<QuizResult>()
                .HasOne(qr => qr.User)
                .WithMany()
                .HasForeignKey(qr => qr.UserId)
                .OnDelete(DeleteBehavior.Restrict); 

        }

    }

}
