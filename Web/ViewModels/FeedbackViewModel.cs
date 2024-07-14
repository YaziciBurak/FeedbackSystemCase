using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class FeedbackViewModel
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FeedbackContent { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
