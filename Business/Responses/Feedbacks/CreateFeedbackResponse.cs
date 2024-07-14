namespace Business.Requests.Feedbacks;

public class CreateFeedbackResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FeedbackContent { get; set; }
}
