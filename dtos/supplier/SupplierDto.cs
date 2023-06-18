using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.models;

namespace WebApplication1.dtos.supplier
{
    public class SupplierDto
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
