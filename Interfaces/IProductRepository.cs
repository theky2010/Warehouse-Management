using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int id);
        ICollection <Product> GetProduct(string name);
        ICollection <Product> GetProductByCategory(int categoryId);
        Product GetPoductTrimToUpper(ProductDto productCreate);
        bool ProductExists(int proId);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();

    }
}
