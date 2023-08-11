

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FeedbackDemo.Controllers;
using FeedbackDemo.Core.Models;
using System.Linq;
using FeedbackProvider.Interfaces;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Extensions.Logging;

namespace FeedbackUnitTest
{
    [TestFixture]
    public class FeedbackAPITesting
    {
        private FeedbackController _controller;
        private Mock<ILogger<FeedbackController>> _logger;
        private Mock<IAddFeedbackService> _mockAddFeedbackService;
        private Mock<IGetFeedbackService> _mockGetFeedbackService;

        [SetUp]
        public void FeedbackControllerTests()
        {
            _mockAddFeedbackService = new Mock<IAddFeedbackService>();
            _mockGetFeedbackService = new Mock<IGetFeedbackService>();
            _logger = new Mock<ILogger<FeedbackController>>();

            _controller = new FeedbackController(
                _mockAddFeedbackService.Object,
                _mockGetFeedbackService.Object,
                _logger.Object
            );
        }

        [Test]
        public void PostFeedback_Valid_Feedback()
        {
            var feedback = new FeedbackDetailsUser
            {
                UserName = "test",
                UserFeedback = "Feedback for testing"
            };

            var result = _controller.PostFeedback(feedback).GetAwaiter().GetResult() as CreatedAtActionResult;

            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(nameof(_controller.PostFeedback), result.ActionName);
            NUnit.Framework.Assert.AreEqual(feedback, result.Value);
            _mockAddFeedbackService.Verify(s => s.AddFeedback(It.IsAny<FeedbackDetailsUser>()), Times.Once);
            
        }
        [Test]
        public void PostFeedback_InValid_Feedback()
        {
            var feedback1 = new FeedbackDetailsUser
            {
                UserName = "",
                UserFeedback = "Feedback for testing"
            };

            var result1 = _controller.PostFeedback(feedback1).GetAwaiter().GetResult() as BadRequestResult;

            NUnit.Framework.Assert.IsNotNull(result1);
            _mockAddFeedbackService.Verify(s => s.AddFeedback(It.IsAny<FeedbackDetailsUser>()), Times.Never());
        }
        [Test]
        public void PostFeedback_Empty_Feedback()
        {
            var feedback1 = new FeedbackDetailsUser
            {
            };

            var result1 = _controller.PostFeedback(feedback1).GetAwaiter().GetResult() as BadRequestResult;
            NUnit.Framework.Assert.IsNotNull(result1);
            _mockAddFeedbackService.Verify(s => s.AddFeedback(It.IsAny<FeedbackDetailsUser>()), Times.Never());
        }

        [Test]
        public async Task GetFeedback_Valid_Parameters()
        {
            var item1 = new PageParameters
            {
                PageNumber = 1,
                PageSize = 10
            };
            _mockGetFeedbackService.Setup(s => s.GetPagedFeedbacks(item1));
            var result = await _controller.GetFeedback(item1) as OkObjectResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(200, result.StatusCode);
            var actualFeedbacks = result.Value as IEnumerable<FeedbackDetails>;
            NUnit.Framework.Assert.IsNotNull(actualFeedbacks);
            _mockGetFeedbackService.Verify(s => s.GetPagedFeedbacks(item1), Times.Once);
        }
        [Test]
        public async Task GetFeedback_Invalid_Parameters()
        {
            var item1 = new PageParameters
            {
                PageNumber = 0,
                PageSize = 100
            };
            _mockGetFeedbackService.Setup(s => s.GetPagedFeedbacks(item1));
            var result = await _controller.GetFeedback(item1) as OkObjectResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(200, result.StatusCode);
            var actualFeedbacks = result.Value as IEnumerable<FeedbackDetails>;
            NUnit.Framework.Assert.IsNotNull(actualFeedbacks);
            _mockGetFeedbackService.Verify(s => s.GetPagedFeedbacks(item1), Times.Once);
        }
        [Test]
        public async Task GetFeedback_Empty_Parameters()
        {
            var item1 = new PageParameters
            {
               
            };
            _mockGetFeedbackService.Setup(s => s.GetPagedFeedbacks(item1));
            var result = await _controller.GetFeedback(item1) as OkObjectResult;
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(200, result.StatusCode);
            var actualFeedbacks = result.Value as IEnumerable<FeedbackDetails>;
            NUnit.Framework.Assert.IsNotNull(actualFeedbacks);
            _mockGetFeedbackService.Verify(s => s.GetPagedFeedbacks(item1), Times.Once);
        }
    }
}

