using WareHouseManagment.Dto;
using WareHouseManagment.Models;

namespace WareHouseManagment.Interfaces
{
    public interface IUserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(int id);
        ICollection<User> GetUsersName(string name);
        User GetUserTrimToUpper(UserDto userCreate);
        bool CreateUser(User User);
        bool UpdateUser(User User);
        bool DeleteUser(User User);
        bool UserExists(int id);


    }
}
