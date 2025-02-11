using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IProductoServicio
    {
        Task<ReponseDTO<List<ProductoDTO>>> Lista(string buscar);
        Task<ReponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);
        Task<ReponseDTO<ProductoDTO>> Obtener(int id);
        Task<ReponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);
        Task<ReponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ReponseDTO<bool>> Eliminar(int id);
    }
}
