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
using Microsoft.Extensions.Logging;

namespace FeedbackProvider.Services
{
    
    public class AddFeedbackService : IAddFeedbackService
    {
        private readonly FeedbackDBContext _dbContext;
        private readonly ILogger<AddFeedbackService> _logger;
        public AddFeedbackService(FeedbackDBContext dbContext,ILogger<AddFeedbackService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<FeedbackDetailsUser> AddFeedback(FeedbackDetailsUser feedbackobj)
        {
            _logger.LogInformation("Add Feedback Service initiated");
            try
            {
                var details = new FeedbackDetails() { Date_Time = DateTime.Now, UserFeedback = feedbackobj.UserFeedback, UserName = feedbackobj.UserName, Id = 0 };
                await _dbContext.UserFeedbacks.AddAsync(details);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("Feedback added successfully to the Database");
                return feedbackobj;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex);
                throw new Exception(ex.Message);
            }
            
        }
    }
}
