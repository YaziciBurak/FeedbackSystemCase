using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class CreateFeedbackRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
