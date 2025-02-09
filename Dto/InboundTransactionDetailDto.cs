using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class InboundTransactionDetailDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }        
        public int InboundTransactionId { get; set; }        
        public int WarehouseLocationId { get; set; }
    }
}
