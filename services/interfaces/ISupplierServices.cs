using WebApplication1.dtos.supplier;

namespace WebApplication1.services.interfaces
{
    public interface ISupplierServices
    {
        List<SupplierDto> GetSuppliersHaveHighestPoit(int storeId);
    }
}
