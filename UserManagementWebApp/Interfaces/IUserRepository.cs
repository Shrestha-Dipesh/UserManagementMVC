using UserManagementWebApp.Models;

namespace UserManagementWebApp.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User GetById(int id);
        public List<User> GetByKeyword(string keyword);
        public bool Add(User user);
        public bool Update(User user);
        public bool Delete(User user);
        public bool Save();
    }
}
