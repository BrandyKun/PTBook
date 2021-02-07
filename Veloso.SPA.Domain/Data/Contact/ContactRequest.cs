using System.ComponentModel.DataAnnotations;

namespace Veloso.SPA.Domain
{
    public class ContactRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Message { get; set; }
    }
}