using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface ISupplierRepository
    {
        ICollection<Supplier> GetSuppliers();
        Supplier GetSupplier(int id);
        ICollection<Supplier> GetSupplier(string name);
        Supplier GetSupplierTrimToUpper(SupplierDto supplierCreate);
        bool SupplierExists(int id);
        bool CreateSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplier);
        bool DeleteSupplier(Supplier supplier);
        bool Save();
    }
}
