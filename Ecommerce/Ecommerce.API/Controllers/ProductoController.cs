using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Ecommerce.Servicio.Contrato;
using Ecommerce.DTO;
using Ecommerce.Servicio.Implementacion;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServicio _productoServicio;
        public ProductoController(IProductoServicio productoServicio)
        {
            _productoServicio = productoServicio;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "N/A")
        {
            var response = new ReponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "N/A")
                {
                    buscar = "";
                }

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Lista(buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "N/A")
        {
            var response = new ReponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos")
                {
                    categoria = "";
                }

                if (buscar == "N/A")
                {
                    buscar = "";
                }

                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Catalogo(categoria,buscar);

            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Obtener/{id:int}")]
        public async Task<IActionResult> Obtener(int id)
        {
            var response = new ReponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO modelo)
        {
            var response = new ReponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO modelo)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productoServicio.Eliminar(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
