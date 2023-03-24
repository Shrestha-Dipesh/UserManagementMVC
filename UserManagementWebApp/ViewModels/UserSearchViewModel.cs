using UserManagementWebApp.Models;

namespace UserManagementWebApp.ViewModels
{
    public class UserSearchViewModel
    {
        public List<User> Users { get; set; }
        public string Keyword { get; set; }
    }
}
