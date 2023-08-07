using FeedbackDemo.Core.Models;
using FeedbackProvider.Context;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace FeedbackProvider.Services
{
    public class GetFeedbackService : IGetFeedbackService
    {
        private readonly FeedbackDBContext _dbContext;
        public GetFeedbackService(FeedbackDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<FeedbackDetails>> GetAllFeedbacks()
        {
            return await _dbContext.UserFeedbacks.ToListAsync();
        }
    }
}
