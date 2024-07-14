namespace Business.Profiles.Feedbacks;

public class CreateFeedbackRequest
{
    public int UserId { get; set; }
    public string FeedbackContent { get; set; }
}
