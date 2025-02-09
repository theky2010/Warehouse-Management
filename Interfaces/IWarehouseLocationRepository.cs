using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IWarehouseLocationRepository
    {
        bool WarehouseLocationExists(int id);
        WarehouseLocation GetWarehouseLocation(int id);
        ICollection<WarehouseLocation> GetWarehouseLocation(string name);
        ICollection<WarehouseLocation> GetWarehouseLocations();
        ICollection<WarehouseLocation> GetWarehouseLocationByWarehouse(int id);
        bool CreateWarehouseLocation(WarehouseLocation warehouseLocation);
        bool UpdateWarehouseLocation(WarehouseLocation warehouseLocation);
        bool DeleteWarehouseLocation(WarehouseLocation warehouseLocation);
        bool Save();
    }
}
