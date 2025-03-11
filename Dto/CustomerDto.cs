using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Info { get; set; }
    }
}
