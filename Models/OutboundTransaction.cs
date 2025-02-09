namespace WareHouseManagment.Models
{
    public class OutboundTransaction
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public ICollection<OutboundTransactionDetail> outboundTransactionDetails { get; set; }
    }
}
