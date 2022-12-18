using System.ComponentModel.DataAnnotations;


namespace WebPortfolioMVC.Models
{
    public class MessageModel
    {
        [Required(ErrorMessage =("Email is required"))]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = ("Name is required"))]
        [StringLength(maximumLength: 50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "Subject must be between 1 and 100 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [StringLength(maximumLength:1000, MinimumLength = 1, ErrorMessage = "Message must be between 1 and 1000 characters")]
        public string Message { get; set; }
    }
}
