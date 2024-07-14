namespace Business.Requests.Feedbacks;

public class UpdateFeedbackRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FeedbackContent { get; set; }
}
