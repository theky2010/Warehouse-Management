using System.ComponentModel.DataAnnotations;
using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class OutboundTransactionDto
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int WarehouseId { get; set; }
    }
}
