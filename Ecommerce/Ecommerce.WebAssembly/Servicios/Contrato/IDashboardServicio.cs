using Ecommerce.DTO;

namespace Ecommerce.WebAssembly.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ReponseDTO<DashboardDTO>> Resumen();   
    }
}
