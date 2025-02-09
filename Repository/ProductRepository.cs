    using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{

    public class ProductRepository : IProductRepository
    {
        private DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public bool ProductExists(int proId)
        {
            return _context.Products.Any(e => e.Id == proId);
        }

        public Product GetProduct(int id)
        {
            return _context.Products.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Product> GetProductByCategory(int categoryId)
        {
            return _context.Products.Where(e => e.CategoryId == categoryId).ToList();
        }

        public ICollection<Product>GetProduct(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Products.AsEnumerable().Where(e => e.Name.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.Name.ToLower()).Contains(normalizedKeyword)).ToList();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.OrderBy(e => e.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            return Save();
        }
        public bool CreateProduct(Product product)
        {
            try
            {

                _context.Products.Add(product);

                return Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating product: {ex.Message}");
                return false;
            }
        }
        public bool DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return Save();
        }

        public Product GetPoductTrimToUpper(ProductDto productCreate)
        {
            return GetProducts().Where(c => c.Name.Trim().ToUpper() == productCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();
        }
    }
}
