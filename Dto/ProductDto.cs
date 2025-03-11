using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WareHouseManagment.Dto
{
    public class ProductDto
    {   
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage ="Tên sản phẩm không vượt quá 50 ký tự")]
        public string Name { get; set; }
        [Range(1000,500000,ErrorMessage ="Giá nằm trong khoảng từ 1000 -> 500000")]             
        public decimal Price { get; set; }
        [RegularExpression(@"\d+$",ErrorMessage ="Số lượng chỉ được chứa số nguyên")]
        [MinLength(1)]
        public int Total_Quantity { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
