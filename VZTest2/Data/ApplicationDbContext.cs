using Microsoft.EntityFrameworkCore;
using VZTest2.Models.Data;

namespace VZTest2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestThemeBlock> TestThemeBlocks { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Attempt> Attempts { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<OptionAnswer> OptionAnswers { get; set; }
    }
}
