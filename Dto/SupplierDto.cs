using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string SupplierName { get; set; }
        [Required]
        public string SupplierInfo { get; set; }
    }
}
