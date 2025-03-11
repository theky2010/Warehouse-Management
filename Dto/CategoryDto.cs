using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
