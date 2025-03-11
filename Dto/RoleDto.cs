using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class RoleDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
