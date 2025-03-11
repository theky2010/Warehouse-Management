using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50,MinimumLength = 5)]
        public string Username { get; set; }
        [Required]
        [StringLength(100)]
        public string Fassword { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$")]
        public string Email { get; set; }
    }
}
