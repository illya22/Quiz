using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DL.Data
{
    public class AppDbContext: IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Question>? Questions { get; set; }

        public DbSet<Answer>? Answers { get; set; }

        public DbSet<Quiz>? Quizzes { get; set; }

        public DbSet<ApplicationUserQuiz>? UsersQuizzes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserQuiz>()
                .HasKey(x => new { x.CompletedQuizzesId, x.CompletedUsersId });

            builder.Entity<Quiz>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.Quiz)
                .HasForeignKey(x => x.QuizId);
        }
    }
}
