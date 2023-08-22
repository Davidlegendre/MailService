using MailService.Models;

namespace MailServices.Models
{
    public class MailModelForFrom
    {
        public FromUser FromUser { get; set; }
        public string ToUser { get; set; }
        public string Subject { get; set; }
        public bool IsHTMLBody { get; set; } = false;
        public string Body { get; set; }
    }
}
