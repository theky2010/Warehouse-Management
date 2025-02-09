using Microsoft.EntityFrameworkCore;

namespace WareHouseManagment.Dto
{
    public class ProductDto
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        [Precision(18, 4)]
        public decimal Price { get; set; }
        public int Total_Quantity { get; set; }
        public int CategoryId { get; set; }
    }
}
