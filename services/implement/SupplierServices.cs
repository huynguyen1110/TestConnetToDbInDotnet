using AutoMapper;
using WebApplication1.dbcontext;
using WebApplication1.dtos.supplier;
using WebApplication1.models;
using WebApplication1.services.interfaces;

namespace WebApplication1.services.implement
{
    public class SupplierServices : ISupplierServices
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;


        public SupplierServices(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<SupplierDto> GetSuppliersHaveHighestPoit(int storeId)
        {

            var highestIntimacyLevel = _dbContext.SuppliersSupplier
                .Where(ss => ss.Store.Id == storeId)
                .Max(ss => ss.IntimacyLevel);

            var StoreSuppliers = _dbContext.SuppliersSupplier
                .Where(ss => ss.Store.Id == storeId && ss.IntimacyLevel == highestIntimacyLevel)
                .Select(ss => ss.Supplier)
                .ToList();
            var Result = _mapper.Map<List<Supplier>, List<SupplierDto>>(StoreSuppliers);
            return Result;

        }
    }
}
