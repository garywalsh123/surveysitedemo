using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SurveySite.Database.Models;

namespace SurveySite.Database
{
    public class SurveySiteContext : IdentityDbContext<User>
    {
        public SurveySiteContext(DbContextOptions<SurveySiteContext> options) : base(options)
        {
        }

        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }

        public DbSet<Survey> Survey { get; set; }
        public DbSet<SurveyAnswer> SurveyAnswer { get; set; }

        public DbSet<QuestionBank> QuestionBank { get; set; }

    }
}
