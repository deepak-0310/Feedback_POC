
using FeedbackDemo.Core;
using FeedbackDemo.Core.Models;
using FeedbackProvider.Context;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<GetFeedbackService> _logger;
        public GetFeedbackService(FeedbackDBContext dbContext, ILogger<GetFeedbackService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<FeedbackDetails>> GetAllFeedbacks()
        {
            return await _dbContext.UserFeedbacks.ToListAsync();
        }

        public async Task<IEnumerable<FeedbackDetails>> GetPagedFeedbacks(PageParameters pageParameters)
        {
            _logger.LogInformation("Get Paged feedbacks service initiated");
            try
            {
                var skipAmount = (pageParameters.PageNumber - 1) * pageParameters.PageSize;
                var pageddata = await _dbContext.UserFeedbacks.Skip(skipAmount).Take(pageParameters.PageSize).ToListAsync();
                _logger.LogInformation("Creating the page of required feedbacks");
                return Pagination<FeedbackDetails>.Create(pageddata, pageParameters.PageNumber, pageParameters.PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message,ex);
                throw new Exception(ex.Message);
            }
            
        }
    }
}
