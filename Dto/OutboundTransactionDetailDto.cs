using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class OutboundTransactionDetailDto
    {
        public int Id { get; set; }
        public int OutboundTransactionId { get; set; }

        public int ProductId { get; set; }
       

        public int WarehouseLocationId { get; set; }
        
        public int Quantity { get; set; }
    }
}
