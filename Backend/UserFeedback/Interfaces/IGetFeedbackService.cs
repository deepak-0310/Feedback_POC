using Microsoft.AspNetCore.Mvc;

namespace UserFeedback.Interfaces
{
    public interface IGetFeedbackService
    {
        JsonResult GetAllFeedbacks();
    }
}