using ShalomMailService.Models;

namespace ShalomMailServices.Models
{
    public class MailModelForFrom
    {
        public string ToUser { get; set; }
        public string Subject { get; set; }
        public bool IsHTMLBody { get; set; } = false;
        public string Body { get; set; }
    }
}
