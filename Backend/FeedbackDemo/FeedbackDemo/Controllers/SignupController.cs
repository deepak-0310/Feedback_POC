//using FeedbackDemo.Core.Models;
//using FeedbackProvider.Context;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace FeedbackDemo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SignupController : ControllerBase
//    {
//        private readonly FeedbackDBContext _dbContext;
//        public SignupController(FeedbackDBContext feedbackDBContext) { 
//            _dbContext = feedbackDBContext;
//        }
//        [HttpPost("register")]
//        public async Task<IActionResult> Register([FromBody] SignupDetails signupObj)
//        {
//            if(signupObj == null)
//            {
//                return BadRequest();
//            }
//            await _dbContext.SignupDetails.AddAsync(signupObj);
//            await _dbContext.SaveChangesAsync();
//            return Ok(new
//            {
//                Message="User Registered!"
//            }) ;
//        }
//        [HttpPost("authenticate")]
//        public async Task<IActionResult> Authenticate([FromBody] SigninDetails signinObj)
//        {
//            if(signinObj == null)
//            {
//                return BadRequest();
//            }
//            var user = await _dbContext.SignupDetails.FirstOrDefaultAsync(u=> u.Email==signinObj.Email && u.Password==signinObj.Password);
//            if(user== null)
//            {
//                return NotFound(new { Message = "User Not Found!" });
//            }
//            return Ok(new
//            {
//                Message="Loggin Successfull!"
//            });
//        }
//    }
//}
using FeedbackDemo.Core.Models;
using FeedbackDemo.Core.Services;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FeedbackDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly ISignupService _signupService;
        private readonly ILogger<SignupController> _logger;

        public SignupController(ISignupService signupService, ILogger<SignupController> logger)
        {
            _signupService = signupService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignupDetails signupObj)
        {
            _logger.LogInformation("Signup process initiated");
            if (string.IsNullOrWhiteSpace(signupObj.Name) || string.IsNullOrWhiteSpace(signupObj.Email) || string.IsNullOrWhiteSpace(signupObj.Password))
            {
                _logger.LogInformation("The Details are incorrect");
                return BadRequest();
            }

            try
            {
                var registeredUser = await _signupService.RegisterUserAsync(signupObj);
                _logger.LogInformation("User Registered Successfully");
                return Ok(new
                {
                    Message = "User Registered Successfully"
                }) ;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message,ex);
                return StatusCode(500, new { Message = "An error occurred while registering user." });
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] SigninDetails signinObj)
        {
            _logger.LogInformation("Signin process initiated");
            if (string.IsNullOrWhiteSpace(signinObj.Password) || string.IsNullOrWhiteSpace(signinObj.Email))
            {
                _logger.LogInformation("The Details are incorrect");
                return BadRequest();
            }

            try
            {
                var user = await _signupService.AuthenticateUserAsync(signinObj);
                
                if (user == null)
                {
                    _logger.LogInformation("User Not Found");
                    return NotFound(new { Message = "User Not Found!" });
                }
                _logger.LogInformation("Successfully Logged-in");
                return Ok(new
                {
                    Message = "Successfully Logged-in"
                });
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message,ex);
                return StatusCode(500, new { Message = "An error occurred while authenticating user." });
            }
        }
    }
}

