using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.Data;
using UserManagementWebApp.Models;

namespace UserManagementWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (user.Gender == null)
                user.Gender = "N/A";

            if (user.Address == null)
                user.Address = "N/A";

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
