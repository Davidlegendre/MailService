using ShalomMailServices.Controllers;

namespace ShalomMailService.Models
{
    public class FromUser
    {
        public string NombreYApellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TypeEmail IDTipoEmail { get; set; } 

    }
}
