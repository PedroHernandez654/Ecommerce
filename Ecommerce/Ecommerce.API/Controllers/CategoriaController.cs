using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Ecommerce.Servicio.Contrato;
using Ecommerce.DTO;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriaServicio;
        public CategoriaController(ICategoriaServicio categoriaServicio)
        {
            _categoriaServicio = categoriaServicio;
        }

        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista(string buscar = "N/A")
        {
            var response = new ReponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "N/A")
                {
                    buscar = "";
                }

                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Lista(buscar);

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
            var response = new ReponseDTO<CategoriaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Obtener(id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {
            var response = new ReponseDTO<CategoriaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            var response = new ReponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoriaServicio.Editar(modelo);
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
                response.Resultado = await _categoriaServicio.Eliminar(id);
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
