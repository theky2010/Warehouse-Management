using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IInventoryRepository
    {
        bool InventoryExists(int id);
        ICollection<Inventory> GetInventories();
        Inventory GetInventory(int id);
        ICollection<Inventory> GetInventoryByProduct(int id);
        ICollection<Inventory> GetInventoryByLocation(int id);
        bool Save();
        bool CreateInventory(Inventory inventory);
        bool UpdateInventory(Inventory inventory);
        bool DeleteInventory(Inventory inventory);

    }
}
