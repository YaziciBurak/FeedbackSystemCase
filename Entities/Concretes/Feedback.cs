using Core.Entities;
using Core.Utilities.Security.Entities;

namespace Entities.Concretes;

public class Feedback : BaseEntity<int>
{
    public Feedback()
    {

    }
    public Feedback(int userId, string feedbackContent)
    {
        UserId = userId;
        FeedbackContent = feedbackContent;
    }
   
    public int UserId { get; set; }
    public string FeedbackContent { get; set; }
    public virtual User User { get; set; }   

}
