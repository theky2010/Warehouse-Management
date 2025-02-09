using Microsoft.EntityFrameworkCore;
using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly DataContext _context;
        public WarehouseRepository(DataContext datacontext)
        {
            _context = datacontext;
        }
        public Warehouse GetWarehouse(int id)
        {
            return _context.Warehouses.Where(e => e.WarehouseId == id).FirstOrDefault();
        }

        public ICollection<Warehouse> GetWarehouse(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Warehouses.AsEnumerable().Where(e => e.WarehouseName.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.WarehouseName.ToLower()).Contains(normalizedKeyword)).ToList();
        }
        public ICollection<Warehouse> GetLocationWarehouse(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Warehouses.AsEnumerable().Where(e => e.WarehouseLocation.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.WarehouseLocation.ToLower()).Contains(normalizedKeyword)).ToList();
        }
        public ICollection<Warehouse> GetWarehouses()
        {
            return _context.Warehouses.OrderBy(e => e.WarehouseId).ToList();
        }

        public bool WarehouseExists(int id)
        {
            return _context.Warehouses.Any(e => e.WarehouseId == id);
        }

        public bool CreateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            return Save();
        }

        public bool UpdateWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Update(warehouse);
            return Save();
        }

        public bool DeleteWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Remove(warehouse);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
