using FeedbackDemo.Core.Models;

namespace FeedbackProvider.Interfaces
{
    public interface ISignupService
    {
        Task<SigninDetails> AuthenticateUserAsync(SigninDetails signinDetails);
        Task<SignupDetails> RegisterUserAsync(SignupDetails signupDetails);
    }
}