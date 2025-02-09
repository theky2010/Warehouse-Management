using WareHouseManagment.Data;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;

namespace WareHouseManagment.Repository
{
    public class UserRoleRepository:IUserRoleRepository
    {
        private DataContext _context;
        public UserRoleRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CreateUserRole(UserRole userrole)
        {
           
            bool userExists = _context.Users.Any(u => u.Id == userrole.UserId);
                if (!userExists)
                {
                    return false;
                }

            bool roleExists = _context.Roles.Any(u => u.Id == userrole.RoleId);
                if (!userExists)
                {
                    return false;
                }

            bool isExist = _context.UserRoles.Any(ur => ur.UserId == userrole.UserId && ur.RoleId == userrole.RoleId);

                if (isExist)
                {
                    return false;
                }

            _context.Add(userrole);
            return Save();
        }

        public bool DeleteUserRole(UserRole userrole)
        {
            _context.UserRoles.Remove(userrole);
            return Save();
        }

        public ICollection<UserRole> GetUserRoles()
        {
            return _context.UserRoles.OrderBy(c => c.RoleId).ToList();
        }

        public bool UpdateUserRole(UserRole userrole)
        {
            _context.UserRoles.Update(userrole);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public ICollection<UserRole> GetUserRoleByRoleId(int id)
        {
            return _context.UserRoles.Where(c => c.RoleId == id).ToList();
        }

        public UserRole GetUserRoleByUserId(int id)
        {
            return _context.UserRoles.Where(c => c.UserId == id).FirstOrDefault();
        }

        public bool RoleIdExists(int roleId)
        {
            return _context.UserRoles.Any(c => c.RoleId == roleId);
        }

        public bool UserIdExists(int userId)
        {
            return _context.UserRoles.Any(c => c.UserId == userId);
        }
    }
}
