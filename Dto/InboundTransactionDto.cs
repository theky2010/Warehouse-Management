using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class InboundTransactionDto
    {
        public int Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DateTime { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int WarehouseId { get; set; }
    }
}
