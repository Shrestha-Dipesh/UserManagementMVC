using Microsoft.AspNetCore.Mvc;
using UserManagementWebApp.Data;
using UserManagementWebApp.Interfaces;
using UserManagementWebApp.Models;
using UserManagementWebApp.ViewModels;

namespace UserManagementWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            var users = _userRepository.GetAll();
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

            _userRepository.Add(user);
            TempData["success"] = "User added successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == 0)
                return NotFound();

            var user = _userRepository.GetById(id);
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

            _userRepository.Update(user);
            TempData["success"] = "User updated successfully";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            var user = _userRepository.GetById(id);
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
            _userRepository.Delete(user);
            TempData["success"] = "User deleted successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            if (keyword == null)
                return RedirectToAction("Index");

            var users = _userRepository.GetByKeyword(keyword);
            var viewModel = new UserSearchViewModel
            {
                Users = users,
                Keyword = keyword
            };

            return View(viewModel);
        }
    }
}
