using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeedbackDemo.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedbackProvider.Context
{
    public class FeedbackDBContext:DbContext
    {
        public FeedbackDBContext(DbContextOptions<FeedbackDBContext> options):base(options)
        {

        }
        public DbSet<FeedbackDetails> UserFeedbacks{ get; set; }
        public DbSet<SignupDetails> SignupDetails { get; set; }
        
    }
}
