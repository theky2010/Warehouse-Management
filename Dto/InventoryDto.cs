using System.ComponentModel.DataAnnotations;
using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class InventoryDto
    {
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int WarehouseLocationId { get; set; }
    }
}
