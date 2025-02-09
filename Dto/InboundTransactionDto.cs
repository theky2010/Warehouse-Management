using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class InboundTransactionDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int SupplierId { get; set; }
        public int WarehouseId { get; set; }
    }
}
