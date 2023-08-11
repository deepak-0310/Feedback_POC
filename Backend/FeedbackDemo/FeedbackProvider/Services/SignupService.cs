using System;
using System.Linq;
using System.Threading.Tasks;
using FeedbackDemo.Core.Models;
using FeedbackProvider.Context;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FeedbackDemo.Core.Services
{
    public class SignupService : ISignupService
    {
        private readonly FeedbackDBContext _dbContext;
        private readonly ILogger<SignupService> _logger;

        public SignupService(FeedbackDBContext dbContext,ILogger<SignupService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<SignupDetails> RegisterUserAsync(SignupDetails signupDetails)
        {
            _logger.LogInformation("Signup service initiated");
            if (signupDetails == null)
            {
                _logger.LogInformation("The Details are incorrect");
                throw new ArgumentNullException(nameof(signupDetails));
            }
            try
            {
                _dbContext.SignupDetails.Add(signupDetails);
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("The Details are added successfully to the Database");
                return signupDetails;

            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message, ex);
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<SigninDetails> AuthenticateUserAsync(SigninDetails signinDetails)
        {
            _logger.LogInformation("Sginin service initiated");
            if (string.IsNullOrWhiteSpace(signinDetails.Email) || string.IsNullOrWhiteSpace(signinDetails.Password))
            {
                _logger.LogInformation("The Details are incorrect");
                return null;
            }
            try
            {
                var res = await _dbContext.SignupDetails.FirstOrDefaultAsync(u => u.Email == signinDetails.Email);
                if (res == null) { return null; }
                if(!res.Password.Equals(signinDetails.Password))
                {
                    return null;
                }
                
                if (res != null)
                {
                    _logger.LogInformation("User is found");
                    return new SigninDetails
                    {
                        Email = res.Email,
                        Password = res.Password
                    };
                }
                _logger.LogInformation("User is not found");
                return null;
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex.Message, ex);
                throw new Exception(ex.Message);
            }

          
        }
    }
}
