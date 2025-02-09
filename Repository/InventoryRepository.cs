using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class InventoryRepository:IInventoryRepository
    {
        private DataContext _context;
        public InventoryRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateInventory(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            return Save();
        }

        public bool DeleteInventory(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            return Save();
        }

        public ICollection<Inventory> GetInventories()
        {
            return _context.Inventories.OrderBy(e => e.Id).ToList();
        }

        public Inventory GetInventory(int id)
        {
            return _context.Inventories.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<Inventory> GetInventoryByLocation(int id)
        {
            return _context.Inventories.Where(e => e.WarehouseLocationId == id).ToList();
        }

        public ICollection<Inventory> GetInventoryByProduct(int id)
        {
            return _context.Inventories.Where(e => e.ProductId == id).ToList();
        }

        public bool InventoryExists(int id)
        {
            return _context.Inventories.Any(e => e.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateInventory(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
            return Save();
        }
    }
}
