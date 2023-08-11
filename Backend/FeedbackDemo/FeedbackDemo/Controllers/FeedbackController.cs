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
using FeedbackDemo;
using System.Collections.Generic;
using FeedbackProvider.Services;

[Route("api/[controller]")]
[ApiController]
public class FeedbackController : ControllerBase
{
    private readonly IAddFeedbackService _addfeedbackService;
    private readonly IGetFeedbackService _getfeedbackService;
    private readonly ILogger<FeedbackController> _logger;

    public FeedbackController(IAddFeedbackService feedbackService,IGetFeedbackService feedbackService1, ILogger<FeedbackController> logger)
    {
        _addfeedbackService = feedbackService;
        _getfeedbackService = feedbackService1;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> PostFeedback(FeedbackDetailsUser fed)
    {
       _logger.LogInformation("POST Feedback process initiated");
        if(string.IsNullOrWhiteSpace(fed.UserName) || string.IsNullOrWhiteSpace(fed.UserFeedback))
        {
            _logger.LogInformation("The Details are incorrect");
            return BadRequest();
        }
        try
        {
            await _addfeedbackService.AddFeedback(fed);
            _logger.LogInformation("Feedback added successfully");
            return CreatedAtAction(nameof(PostFeedback), fed);
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex.Message, ex);
            return BadRequest(ex.Message);
        }
        
    }

    [HttpGet]
    public  async Task<IActionResult> GetFeedback([FromQuery] PageParameters pageParameters )
    {
        _logger.LogInformation("GET Feedback process initiated");
        if(pageParameters == null)
        {
            _logger.LogInformation("The Details are incorrect");
            return BadRequest();
        }
        try
        {
            var feedbacks = await _getfeedbackService.GetPagedFeedbacks(pageParameters);
            _logger.LogInformation("Feedback was fetched successfully");
            return Ok(feedbacks);

        }
        catch (Exception ex)
        {
           _logger.LogInformation(ex.Message, ex);
            return BadRequest(ex.Message );
        }
       
        
    }

}


