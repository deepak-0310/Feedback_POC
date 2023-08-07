using FeedbackDemo.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackProvider.Interfaces
{
    public interface IAddFeedbackService
    {
        Task<FeedbackDetailsUser> AddFeedback([FromBody] FeedbackDetailsUser feedbackobj);
    }
}