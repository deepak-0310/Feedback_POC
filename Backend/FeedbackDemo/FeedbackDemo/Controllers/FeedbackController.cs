using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using FeedbackDemo.Core.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using FeedbackProvider.Interfaces;
using System.Web.Helpers;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IAddFeedbackService _addfeedbackService;
    private readonly IGetFeedbackService _getfeedbackService;
    //private readonly IDeleteFeedbackService _deletefeedbackService;

    public FeedbackController(IAddFeedbackService feedbackService,IGetFeedbackService feedbackService1)
    {
        _addfeedbackService = feedbackService;
        _getfeedbackService = feedbackService1;
        //_deletefeedbackService = feedbackService2;
    }

    [HttpPost]
    public async Task<IActionResult> PostFeedback(FeedbackDetailsUser fed)
    {
        await _addfeedbackService.AddFeedback(fed);
        return CreatedAtAction(nameof(PostFeedback), fed);  
    }

    [HttpGet]
    public async Task<IActionResult> GetFeedback()
    {
        var feedbacks = await _getfeedbackService.GetAllFeedbacks();
        return Ok(feedbacks);
    }

}


