using System.ComponentModel.DataAnnotations;
using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class OutboundTransactionDetailDto
    {
        public int Id { get; set; }
        [Required]
        public int OutboundTransactionId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]               
        public int WarehouseLocationId { get; set; }
        public int Quantity { get; set; }
    }
}
