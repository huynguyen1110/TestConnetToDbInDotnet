using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.dtos.store
{
    public class StoreDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CloseTime { get; set; }
    }
}
