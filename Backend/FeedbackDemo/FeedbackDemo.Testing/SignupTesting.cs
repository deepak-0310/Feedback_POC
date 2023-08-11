using FeedbackDemo.Controllers;
using FeedbackDemo.Core.Models;
using FeedbackProvider.Context;
using FeedbackProvider.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedbackDemo.Testing
{
    [TestFixture]
    public class SignupTesting
    {
        private SignupController _signupController;
        private Mock<ILogger<SignupController>> _logger;
        private Mock<ISignupService> _mockSignupService;
        
        [SetUp]
        public void SignupControllerTest()
        {
            _mockSignupService = new Mock<ISignupService>();
            _logger= new Mock<ILogger<SignupController>>();
            _signupController = new SignupController( _mockSignupService.Object, _logger.Object);
        }
        [Test]
        public void Post_Valid_Credentials_Signup()
        {
            var signupObj = new SignupDetails
            {
                id = 1,
                Name = "deepak",
                Email = "abc@gmail.com",
                Password = "abc@123"
            };
            _mockSignupService.Setup(service => service.RegisterUserAsync(signupObj)).ReturnsAsync(signupObj);
            var result = _signupController.Register(signupObj).GetAwaiter().GetResult() as OkObjectResult ;
            NUnit.Framework.Assert.IsInstanceOf<OkObjectResult>(result);
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(200, result.StatusCode);
            _mockSignupService.Verify(s=>s.RegisterUserAsync(signupObj), Times.Once());
        }
        [Test]
        public void Post_Empty_Credentials_Signup()
        {
            var signupObj = new SignupDetails
            {

            };
            _mockSignupService.Setup(service => service.RegisterUserAsync(signupObj)).ReturnsAsync(signupObj);
            var result = _signupController.Register(signupObj).GetAwaiter().GetResult() as BadRequestResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(400,result.StatusCode);
            _mockSignupService.Verify(s => s.RegisterUserAsync(signupObj), Times.Never());
        }
        [Test]
        public void Post_Invalid_Credentials_Signup()
        {
            var signupObj = new SignupDetails
            {
                id = 1,
                Name = "",
                Email = "abc@gmail.com",
                Password = "abcb"
            };
            _mockSignupService.Setup(service => service.RegisterUserAsync(signupObj)).ReturnsAsync(signupObj);
            var result = _signupController.Register(signupObj).GetAwaiter().GetResult() as BadRequestResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(400, result.StatusCode);
            _mockSignupService.Verify(s => s.RegisterUserAsync(signupObj), Times.Never());
        }
        [Test]
        public void Post_Valid_Credentials_SignIn()
        {
            var signinObj = new SigninDetails
            {
                Email = "abc@gmail.com",
                Password = "abc@123"
            };
            _mockSignupService.Setup(service => service.AuthenticateUserAsync(signinObj)).ReturnsAsync(signinObj);
            var result = _signupController.Authenticate(signinObj).GetAwaiter().GetResult() as OkObjectResult;
            NUnit.Framework.Assert.IsInstanceOf<OkObjectResult>(result);
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(200, result.StatusCode);
            _mockSignupService.Verify(s => s.AuthenticateUserAsync(signinObj), Times.Once());
        }
        [Test]
        public void Post_InValid_Credentials_SignIn()
        {
            var signinObj = new SigninDetails
            {
                Email = "abc@gmail.com",
                Password = ""
            };
            _mockSignupService.Setup(s => s.AuthenticateUserAsync(signinObj)).ReturnsAsync(signinObj);
            var result = _signupController.Authenticate(signinObj).GetAwaiter().GetResult() as BadRequestResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(400, result.StatusCode);
            _mockSignupService.Verify(s => s.AuthenticateUserAsync(signinObj), Times.Never());
        }
        [Test]
        public void Post_Empty_Credentials_SignIn()
        {
            var signinObj = new SigninDetails
            {
                
            };
            _mockSignupService.Setup(s => s.AuthenticateUserAsync(signinObj)).ReturnsAsync(signinObj);
            var result = _signupController.Authenticate(signinObj).GetAwaiter().GetResult() as BadRequestResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(400, result.StatusCode);
            _mockSignupService.Verify(s => s.AuthenticateUserAsync(signinObj), Times.Never());
        }

    }
}


