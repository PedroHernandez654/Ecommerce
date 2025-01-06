using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese Descripcion")]
        public string? Descripcion { get; set; }

        public int? IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese Precio")]
        public decimal? Precio { get; set; }

        [Required(ErrorMessage = "Ingrese Precio Oferta")]
        public decimal? PrecioOferta { get; set; }

        [Required(ErrorMessage = "Ingrese Cantidad")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese Imagen")]
        public string? Imagen { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
    }
}
