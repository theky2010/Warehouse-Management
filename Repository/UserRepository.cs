using WareHouseManagment.Data;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Utilities;

namespace WareHouseManagment.Repository
{
    public class UserRepository:IUserRepository
    {
        private DataContext _context;

        public UserRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public bool CreateUser(User user)
        {
            user.Fassword = BCrypt.Net.BCrypt.HashPassword(user.Fassword);
            _context.Add(user);
            return Save();
        }

        public bool DeleteUser(User User)
        {
            _context.Users.Remove(User);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(c => c.Id).ToList();
        }

        public ICollection<User> GetUsersName(string name)
        {
            string normalizedKeyword = StringUtilities.RemoveDiacritics(name.ToLower());
            return _context.Users.AsEnumerable().Where(e => e.FullName.ToLower().Contains(name.ToLower()) || StringUtilities.RemoveDiacritics(e.FullName.ToLower()).Contains(normalizedKeyword)).ToList();
        }

        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public bool UpdateUser(User user)
        {
            user.Fassword = BCrypt.Net.BCrypt.HashPassword(user.Fassword);
            _context.Users.Update(user);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        public User GetUserTrimToUpper(UserDto userCreate)
        {
            return GetUsers().Where(c => c.Email.Trim().ToUpper() == userCreate.Email.TrimEnd().ToUpper())
                .FirstOrDefault();
        }
    }
}
