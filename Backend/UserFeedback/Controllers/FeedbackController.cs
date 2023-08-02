using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using UserFeedback.models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UserFeedback.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IAddFeedbackService _addfeedbackService;
    private readonly IGetFeedbackService _getfeedbackService;
    private readonly IDeleteFeedbackService _deletefeedbackService;

    public FeedbackController(IAddFeedbackService feedbackService,IGetFeedbackService feedbackService1,IDeleteFeedbackService feedbackService2)
    {
        _addfeedbackService = feedbackService;
        _getfeedbackService = feedbackService1;
        _deletefeedbackService = feedbackService2;
    }

    [HttpPost]
    public IActionResult PostFeedback(Feedback fed)
    {
        _addfeedbackService.AddFeedback(fed);
        return Ok("Added Successfully");
    }

    [HttpGet]
    public IActionResult GetFeedback()
    {
        var feedbacks = _getfeedbackService.GetAllFeedbacks();
        return Ok(feedbacks);
    }

    [HttpDelete]
    [Route("DeleteFeedback")]
    public IActionResult DeleteFeedback(int id)
    {
        _deletefeedbackService.DeleteFeedback(id);
        return Ok("Deleted Successfully");
    }
}


