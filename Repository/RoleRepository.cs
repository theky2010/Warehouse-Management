using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class RoleRepository:IRoleRepository
    {
        private DataContext _context;
        public RoleRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateRole(Role role)
        {
            _context.Add(role);
            return Save();
        }

        public bool DeleteRole(Role role)
        {
            _context.Roles.Remove(role);
            return Save();
        }

        public ICollection<Role> GetRoles() 
        {
            return _context.Roles.OrderBy(c => c.Id).ToList();
        }
        public Role GetRole(int id)
        {
            return _context.Roles.Where(c => c.Id == id).FirstOrDefault();
        }
        public bool RoleExists(int id)
        {
            return _context.Roles.Any(c => c.Id == id);
        }

        public bool UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
