using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DTO
{
    public class ReponseDTO<T>//Esto es lo que respondera la API, es una clase generica donde T es el modelo que se utilizará
    {
        public T? Resultado { get; set; }
        public bool EsCorrecto { get; set; }
        public string? Mensaje { get; set; }
    }
}
