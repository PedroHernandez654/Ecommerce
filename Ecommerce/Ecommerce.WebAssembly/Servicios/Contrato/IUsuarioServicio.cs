using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IUsuarioServicio
    {
        Task<ReponseDTO<List<UsuarioDTO>>> Lista(string rol, string buscar);
        Task<ReponseDTO<UsuarioDTO>> Obtener(int id);
        Task<ReponseDTO<SesionDTO>> Autorizacion(LoginDTO modelo);
        Task<ReponseDTO<UsuarioDTO>> Crear(UsuarioDTO modelo);
        Task<ReponseDTO<bool>> Editar(UsuarioDTO modelo);
        Task<ReponseDTO<bool>> Eliminar(int id);
    }
}
