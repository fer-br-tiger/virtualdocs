using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Notoria.Models
{
    public class Login
    {
        public Login()
        {

        }

        [Required(ErrorMessage = "El rut es obligatorio")]
        public string Rut { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
