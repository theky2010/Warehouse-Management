using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class OutboundTransactionDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
    }
}
