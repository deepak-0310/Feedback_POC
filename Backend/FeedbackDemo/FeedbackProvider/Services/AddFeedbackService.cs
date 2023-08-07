using FeedbackDemo.Core.Models;
using FeedbackProvider.Context;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace FeedbackProvider.Services
{
    
    public class AddFeedbackService : IAddFeedbackService
    {
        private readonly FeedbackDBContext _dbContext;
        public AddFeedbackService(FeedbackDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FeedbackDetailsUser> AddFeedback(FeedbackDetailsUser feedbackobj)
        {
            var details = new FeedbackDetails() { Date_Time = DateTime.Now, UserFeedback = feedbackobj.UserFeedback, UserName = feedbackobj.UserName,  Id = 0};
            Console.WriteLine(feedbackobj.UserName);
           await _dbContext.UserFeedbacks.AddAsync(details);
            await _dbContext.SaveChangesAsync();
            return feedbackobj;
        }
    }
}
