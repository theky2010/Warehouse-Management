using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<Role> GetRoles();
        Role GetRole(int id);
        bool CreateRole(Role role);
        bool UpdateRole(Role role);
        bool DeleteRole(Role role);
        bool RoleExists(int id);
    }
}
