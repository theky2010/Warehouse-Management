namespace WareHouseManagment.Models
{
    public class InboundTransaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
        public ICollection <InboundTransactionDetail> inboundTransactionDetails { get; set; }
    }
}
