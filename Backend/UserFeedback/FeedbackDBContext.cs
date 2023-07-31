using Microsoft.EntityFrameworkCore;
using UserFeedback.models;

namespace UserFeedback
{
    public class FeedbackDBContext:DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Set your SQL Server connection string here
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\\\demo;Initial Catalog=FeedbackDB;Integrated Security=True;");
        }
    }
}
