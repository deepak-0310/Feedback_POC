using UserFeedback.models;

namespace UserFeedback.Interfaces
{
    public interface IAddFeedbackService
    {
        void AddFeedback(Feedback fed);
    }
}