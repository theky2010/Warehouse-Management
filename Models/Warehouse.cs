namespace WareHouseManagment.Models
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseLocation { get; set; }

        public ICollection<WarehouseLocation> warehouseLocations { get; set; }
        public ICollection<InboundTransaction> inboundTransactions { get; set; }
        public ICollection <OutboundTransaction> outboundTransactions { get; set; }
    }
}
