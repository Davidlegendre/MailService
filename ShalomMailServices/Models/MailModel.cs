namespace ShalomMailService.Models
{
    public class MailModel
    {
        //public FromUser FromUser { get; set; }
        public List<ToUser> ToUser { get; set; }
        public string Subject { get; set; }
        public bool IsHTMLBody { get; set; } = false;
        public string Body { get; set; }
    }
}
