using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IVentaServicio
    {
        Task<ReponseDTO<VentaDTO>> Crear(VentaDTO modelo);
    }
}
