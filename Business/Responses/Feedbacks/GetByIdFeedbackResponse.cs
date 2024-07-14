namespace Business.Responses.Feedbacks;

public class GetByIdFeedbackResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FeedbackContent { get; set; }
}
