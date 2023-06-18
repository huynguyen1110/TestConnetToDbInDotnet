using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.dtos.common;
using WebApplication1.dtos.store;
using WebApplication1.models;

namespace WebApplication1.services
{
    public interface IStoreServices
    {
        StoreDto CreateStore(StoreDto createStoreDto);
        StoreDto UpdateStore (StoreDto updateStoreDto, int id);
        Store DeleteById(int id);
        PageResultDto<StoreDto> GetAll(FillterDto fillterDto);


    }
}
