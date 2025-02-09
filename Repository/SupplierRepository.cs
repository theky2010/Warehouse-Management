using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DataContext _context;
        public SupplierRepository(DataContext dataContext)
        {
            _context = dataContext;
        }

        public bool CreateSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            return Save();
        }

        public bool DeleteSupplier(Supplier supplier)
        {
            _context.Suppliers.Remove(supplier);
            return Save();
        }

        public Supplier GetSupplier(int id)
        {
            return _context.Suppliers.Where(e => e.SupplierId == id).FirstOrDefault();
        }

        public ICollection<Supplier> GetSupplier(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Suppliers.AsEnumerable().Where(e => e.SupplierName.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.SupplierName.ToLower()).Contains(normalizedKeyword)).ToList();
        }

        public ICollection<Supplier> GetSuppliers()
        {
            return _context.Suppliers.OrderBy(e => e.SupplierId).ToList();
        }

        public Supplier GetSupplierTrimToUpper(SupplierDto supplierCreate)
        {
            return GetSuppliers().Where(c => c.SupplierName.Trim().ToUpper() == supplierCreate.SupplierName.TrimEnd().ToUpper())
                .FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            _context.Suppliers.Update(supplier);
            return Save();
        }
    }
}
