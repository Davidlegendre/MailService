
using System.ComponentModel.DataAnnotations;

namespace MailService.Models
{
    public class MailModel
    {
        [Required]
        public FromUser FromUser { get; set; }
        [Required]
        public List<ToUser> ToUser { get; set; }

        [Required]
        public string Subject { get; set; }
        [Required]
        public bool IsHTMLBody { get; set; } = false;
        [Required]
        public string Body { get; set; }
    }
}
