using System.ComponentModel.DataAnnotations;

namespace MailService.Models
{
    public class ToUser
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
