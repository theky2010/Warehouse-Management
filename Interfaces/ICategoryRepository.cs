using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int id);
        ICollection<Category> GetCategoryS(string name);

        bool CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(Category category);
        bool CategoryExists(int id);
    }
}
