using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class DeleteFeedbackRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
