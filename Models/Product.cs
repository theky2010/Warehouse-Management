using Microsoft.EntityFrameworkCore;

namespace WareHouseManagment.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Precision(18, 4)]
        public decimal Price { get; set; }
        public int Total_Quantity { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Inventory> inventories { get; set; }
        public ICollection<InboundTransactionDetail> inboundDetails { get; set; }
        public ICollection<OutboundTransactionDetail> outboundTransactionDetails { get; set; }
    }
}
