namespace WebApplication1.models
{
    public class StoreSupplier
    {
        public int StoreId { get; set; }
        public Store Store { get; set; }

        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        public int IntimacyLevel { get; set; }
    }
}
