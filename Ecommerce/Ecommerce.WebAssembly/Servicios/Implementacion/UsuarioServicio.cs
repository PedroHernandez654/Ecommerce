using Ecommerce.DTO;
using Ecommerce.WebAssembly.Servicios.Contrato;
using System.Net.Http.Json;
using System.Reflection;

namespace Ecommerce.WebAssembly.Servicios.Implementacion
{
    public class UsuarioServicio:IUsuarioServicio
    {
        private readonly HttpClient _httpClient;
        public UsuarioServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ReponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion",modelo);

            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<SesionDTO>>();

            return result;
        }

        public async Task<ReponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", modelo);

            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<UsuarioDTO>>();

            return result;
        }

        public async Task<ReponseDTO<bool>> Editar(UsuarioDTO modelo)
        {
            var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", modelo);

            var result = await response.Content.ReadFromJsonAsync<ReponseDTO<bool>>();

            return result;
        }

        public async Task<ReponseDTO<bool>> Eliminar(int id)
        {
            return  await _httpClient.DeleteFromJsonAsync<ReponseDTO<bool>>($"Usuario/Eliminar/{id}");
        }

        public async Task<ReponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }

        public async Task<ReponseDTO<UsuarioDTO>> Obtener(int id)
        {
            return await _httpClient.GetFromJsonAsync<ReponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        }
    }
}
