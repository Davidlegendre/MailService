using MailServices.Controllers;
using System.ComponentModel.DataAnnotations;

namespace MailService.Models
{
    public class FromUser
    {
        [Required]
        public string NombreYApellido { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        internal TypeEmail IDTipoEmail => TypeEmail.Gmail;

    }
}
