using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Quiz> Quizs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswerOptions> Answers { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
    }
}
