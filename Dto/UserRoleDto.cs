using System.ComponentModel.DataAnnotations;
using WareHouseManagment.Models;

namespace WareHouseManagment.Dto
{
    public class UserRoleDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int RoleId { get; set; }
    }
}
