namespace WareHouseManagment.Models
{
    public class OutboundTransactionDetail
    {
        public int Id { get; set; }
        public int OutboundTransactionId { get; set; }
        public OutboundTransaction OutboundTransaction { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int WarehouseLocationId { get; set; }
        public WarehouseLocation WarehouseLocation { get; set; }

        public int Quantity { get; set; }
    }
}
