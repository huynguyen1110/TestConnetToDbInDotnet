using Microsoft.AspNetCore.Mvc;
using WebApplication1.services.interfaces;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class SupplierControllers : Controller
    {

        private readonly ISupplierServices _supplierServices;

        public SupplierControllers(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
        }

        [HttpGet("get-by-store-id")]
        public ActionResult GetHasHighestScore(int id)
        {
            try
            {
                return Ok(_supplierServices.GetSuppliersHaveHighestPoit(id));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
