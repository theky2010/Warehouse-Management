using Microsoft.EntityFrameworkCore;
using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _context;

        public  CategoryRepository(DataContext context)
        {
            _context = context;
        }
        bool ICategoryRepository.CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.OrderBy(e => e.Id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(e => e.Id == id).FirstOrDefault();
        }
        public ICollection< Category> GetCategoryS(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Categories.AsEnumerable().Where(e => e.Name.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.Name.ToLower()).Contains(normalizedKeyword)).ToList();
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
