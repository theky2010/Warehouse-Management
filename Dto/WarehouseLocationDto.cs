using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class WarehouseLocationDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public int WarehouseId { get; set; }
    }
}
