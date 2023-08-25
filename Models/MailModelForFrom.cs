using MailService.Models;
using System.ComponentModel.DataAnnotations;

namespace MailServices.Models
{
    public class MailModelForFrom
    {
        [Required]
        public string ToUser { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public bool IsHTMLBody { get; set; } = false;
        [Required]
        public string Body { get; set; }
    }
}
