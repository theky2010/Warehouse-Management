using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IUserRoleRepository
    {
        ICollection<UserRole> GetUserRoles();
        ICollection<UserRole> GetUserRoleByRoleId(int id);
        bool RoleIdExists(int roleId);
        bool UserIdExists(int userId);
        UserRole GetUserRoleByUserId(int id);
        bool CreateUserRole(UserRole userrole);
        bool UpdateUserRole(UserRole userrole);
        bool DeleteUserRole(UserRole userrole);
    }
}
