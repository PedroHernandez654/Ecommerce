using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface ICategoriaServicio
    {
        Task<ReponseDTO<List<CategoriaDTO>>> Lista(string buscar);
        Task<ReponseDTO<CategoriaDTO>> Obtener(int id);
        Task<ReponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);
        Task<ReponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ReponseDTO<bool>> Eliminar(int id);
    }
}
