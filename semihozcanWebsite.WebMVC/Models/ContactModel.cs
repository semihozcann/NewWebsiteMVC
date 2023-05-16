using System.ComponentModel.DataAnnotations;

namespace semihozcanWebsite.WebMVC.Models
{
    public class ContactModel
    {
        [Required, Display(Name = "Sender Name")]
        public string SenderName { get; set; }

        [Required, Display(Name = "Sender Email"), EmailAddress]
        public string SenderEmail { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public string ViewBagMessage { get; set; }
    }
}
