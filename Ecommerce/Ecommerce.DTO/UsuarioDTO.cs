using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Apellido Materno")]
        public string? ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Ingrese Apellido Paterno")]
        public string? ApellidoPaterno { get; set; }

        [Required(ErrorMessage = "Ingrese Correo")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "Ingrese contraseña")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Ingrese cofirmar contraseña")]
        public string? ConfirmarClave { get; set; }

        public string? Rol { get; set; }
    }
}
