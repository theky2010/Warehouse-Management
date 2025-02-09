using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IWarehouseRepository
    {
        ICollection<Warehouse> GetWarehouses();
        Warehouse GetWarehouse(int id);
        ICollection <Warehouse> GetWarehouse(string name);
        ICollection<Warehouse> GetLocationWarehouse(string name);
        bool WarehouseExists(int id);
        bool CreateWarehouse(Warehouse warehouse);
        bool UpdateWarehouse(Warehouse warehouse);
        bool DeleteWarehouse(Warehouse warehouse);
        bool Save();
    }
}
