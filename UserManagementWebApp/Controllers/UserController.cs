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
            TempData["success"] = "User added successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            if (user.Gender == "N/A")
                user.Gender = null;

            if (user.Address == "N/A")
                user.Address = null;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (user.Gender == null)
                user.Gender = "N/A";

            if (user.Address == null)
                user.Address = "N/A";

            _context.Users.Update(user);
            _context.SaveChanges();
            TempData["success"] = "User updated successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            if (user.Gender == "N/A")
                user.Gender = null;

            if (user.Address == "N/A")
                user.Address = null;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            TempData["success"] = "User deleted successfully";

            return RedirectToAction("Index");
        }
    }
}
