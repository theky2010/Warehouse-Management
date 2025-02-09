namespace WareHouseManagment.Models
{
    public class InboundTransactionDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
      
        public int ProductId { get; set; }     
        public Product Product { get; set; }
        public int InboundTransactionId { get; set; }
        public InboundTransaction InboundTransaction { get; set; }
        public int WarehouseLocationId { get; set; }
        public WarehouseLocation WarehouseLocation { get; set; }

    }
}
