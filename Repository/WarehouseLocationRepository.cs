using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class WarehouseLocationRepository:IWarehouseLocationRepository
    {
        private DataContext _context;
        public WarehouseLocationRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocations.Add(warehouseLocation);
            return Save();
        }

        public bool DeleteWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocations.Remove(warehouseLocation);
            return Save();
        }

        public WarehouseLocation GetWarehouseLocation(int id)
        {
            return _context.WarehouseLocations.Where(e => e.Id == id).FirstOrDefault();
        }

        public ICollection<WarehouseLocation> GetWarehouseLocation(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.WarehouseLocations.AsEnumerable().Where(e => e.Name.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.Name.ToLower()).Contains(normalizedKeyword)).ToList();
        }

        public ICollection<WarehouseLocation> GetWarehouseLocationByWarehouse(int id)
        {
            return _context.WarehouseLocations.Where(e => e.WarehouseId == id).ToList();
        }

        public ICollection<WarehouseLocation> GetWarehouseLocations()
        {
            return _context.WarehouseLocations.OrderBy(e => e.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateWarehouseLocation(WarehouseLocation warehouseLocation)
        {
            _context.WarehouseLocations.Update(warehouseLocation);
            return Save();
        }

        public bool WarehouseLocationExists(int id)
        {
            return _context.WarehouseLocations.Any(e => e.Id == id);
        }
    }
}
