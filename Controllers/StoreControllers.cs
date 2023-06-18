using Microsoft.AspNetCore.Mvc;
using WebApplication1.dtos.common;
using WebApplication1.dtos.store;
using WebApplication1.models;
using WebApplication1.services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class StoreControllers : ControllerBase
    {

        private readonly IStoreServices _storeServices;

        public StoreControllers(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }

        [HttpPost("create-product")]
        public ActionResult CreateStore(StoreDto createStoreDto)
        {
            try
            {
                var newStore = _storeServices.CreateStore(createStoreDto);
                if (newStore != null)
                {
                    return Ok(newStore);
                }
                return BadRequest("Ten san pham da ton tai");
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-store")]
        public ActionResult UpdateStore(StoreDto updateStoreDto, int id)
        {
            try
            {
                var NewStore = _storeServices.UpdateStore(updateStoreDto, id);
                if (NewStore != null)
                {
                    return Ok(NewStore);
                }
                return BadRequest("Tên sản phẩm đã tồn tại");
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-by-id")]
        public ActionResult DeleteStoreById(int id)
        {
            try
            {
                var StoreToDelete = _storeServices.DeleteById(id);
                if (StoreToDelete != null)
                {
                    return Ok("xoa thanh cong cua hang: " + StoreToDelete.Name);
                }
                else
                {
                    return BadRequest("Cua hang khong ton tai");
                }
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all")]
        public ActionResult GetALl([FromQuery] FillterDto fillterDto)
        {
            try
            {
                return Ok(_storeServices.GetAll(fillterDto));
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
