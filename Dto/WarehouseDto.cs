using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class WarehouseDto
    {
        public int WarehouseId { get; set; }
        [Required]
        [StringLength(50)]
        public string WarehouseName { get; set; }
        [Required]
        [StringLength(20)]
        public string WarehouseLocation { get; set; }
    }
}
