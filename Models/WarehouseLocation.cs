namespace WareHouseManagment.Models
{
    public class WarehouseLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }

        public ICollection<InboundTransactionDetail> inboundTransactionDetails { get; set; }

        public ICollection<OutboundTransactionDetail> outboundTransactionDetails { get; set; }

        public ICollection<Inventory> inventories { get; set; }


    }
}
