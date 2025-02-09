using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class InventoryDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int WarehouseLocationId { get; set; }
    }
}
