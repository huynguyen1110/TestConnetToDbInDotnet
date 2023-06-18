using AutoMapper;
using WebApplication1.dbcontext;
using WebApplication1.dtos.common;
using WebApplication1.dtos.store;
using WebApplication1.models;

namespace WebApplication1.services.implement
{
    public class StoreServices : IStoreServices
    {

        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public StoreServices(IMapper mapper, AppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public StoreDto CreateStore(StoreDto createStoreDto)
        {
            var query = _dbContext.Stores.AsQueryable();
            if (query.Any(s => s.Name == createStoreDto.Name))
            {
                return null;
            }
            var store = _mapper.Map<StoreDto, Store>(createStoreDto);
            _dbContext.Stores.Add(store);
            _dbContext.SaveChanges();
            return createStoreDto;
        }

        public StoreDto UpdateStore(StoreDto updateStoreDto, int id)
        {
            var OldStore = _dbContext.Stores.FirstOrDefault(s => s.Id == id);
            if(_dbContext.Stores.Any(s => s.Name == updateStoreDto.Name))
            {
                return null;
            }
            var NewStore = _mapper.Map(updateStoreDto, OldStore);
            _dbContext.SaveChanges();
            return updateStoreDto;
        }

        public Store DeleteById(int id)
        {
            var StoreToDelete = _dbContext.Stores.FirstOrDefault(s => s.Id == id);
            if (StoreToDelete != null)
            {
                _dbContext.Remove(StoreToDelete);
                return StoreToDelete;
            }
            return null;
        }

        public PageResultDto<StoreDto> GetAll(FillterDto fillterDto)
        {
            var result = new PageResultDto<StoreDto>();
            var query = _dbContext.Stores
                .Where(s => s.Name.Contains(fillterDto.Keyword) || s.Address.Contains(fillterDto.Keyword))
                    .Select(store => new StoreDto
                    {
                        Name = store.Name,
                        Address = store.Address,
                        CloseTime = store.CloseTime
                    });
            result.TotalItem = query.Count();
            query = query
                .OrderByDescending(s => s.Name)
                .Skip(fillterDto.Skip())
                .Take(fillterDto.PageSize);

            result.Items = query.ToList();
            return result;
        }
    }
}
