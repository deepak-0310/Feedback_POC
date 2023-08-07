

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FeedbackDemo.Controllers;
using FeedbackDemo.Core.Models;
using System.Linq;
using FeedbackProvider.Interfaces;
using System.Threading.Tasks;

namespace FeedbackUnitTest
{
    [TestClass]
    public class FeedbackAPITesting
    {
        private FeedbackController _controller;
        private Mock<IAddFeedbackService> _mockAddFeedbackService;
        private Mock<IGetFeedbackService> _mockGetFeedbackService;

        [TestInitialize]
        public void FeedbackControllerTests()
        {
            _mockAddFeedbackService = new Mock<IAddFeedbackService>();
            _mockGetFeedbackService = new Mock<IGetFeedbackService>();

            _controller = new FeedbackController(
                _mockAddFeedbackService.Object,
                _mockGetFeedbackService.Object
            );
        }

        [TestMethod]
        public void PostFeedback_ValidFeedback_ReturnsCreatedAtAction()
        {
            var feedback = new FeedbackDetailsUser
            {
                UserName = "test",
                UserFeedback = "Feedback for testing"
            };

            var result = _controller.PostFeedback(feedback).GetAwaiter().GetResult() as CreatedAtActionResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(nameof(_controller.PostFeedback), result.ActionName);
            Assert.AreEqual(feedback, result.Value);
            _mockAddFeedbackService.Verify(s => s.AddFeedback(It.IsAny<FeedbackDetailsUser>()), Times.Once);
        }

        [TestMethod]
        public async Task GetFeedback_ReturnsOkWithFeedbacks()
        {
            var item1 = new FeedbackDetails
            {
                UserName = "kouhsik test",
                UserFeedback = "feedback test by koushik",
                Id = 0,
                Date_Time = DateTime.Now
            };
            var item2 = new FeedbackDetails
            {
                UserName = "deepak test",
                UserFeedback = "feedback test by deepak",
                Id = 10,
                Date_Time = DateTime.Now
            };
            var feedbacks = new List<FeedbackDetails>
            {
                item1, item2
            };

            _mockGetFeedbackService.Setup(s => s.GetAllFeedbacks()).ReturnsAsync(feedbacks);


            var result = await _controller.GetFeedback() as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            var actualFeedbacks = result.Value as IEnumerable<FeedbackDetails>;
            Assert.IsNotNull(actualFeedbacks);
            Assert.AreEqual(feedbacks.Count, actualFeedbacks.Count());
            _mockGetFeedbackService.Verify(s => s.GetAllFeedbacks(), Times.Once);
        }
    }
}

