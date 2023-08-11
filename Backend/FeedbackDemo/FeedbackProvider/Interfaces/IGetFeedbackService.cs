using FeedbackDemo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackProvider.Interfaces
{
    public interface IGetFeedbackService
    {
        Task<IEnumerable<FeedbackDetails>> GetAllFeedbacks();
        Task<IEnumerable<FeedbackDetails>> GetPagedFeedbacks(PageParameters pageParameters);
    }
}