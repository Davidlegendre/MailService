using MailServices.Controllers;

namespace MailService.Models
{
    public class FromUser
    {
        public string NombreYApellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        internal TypeEmail IDTipoEmail => TypeEmail.Gmail;

    }
}
