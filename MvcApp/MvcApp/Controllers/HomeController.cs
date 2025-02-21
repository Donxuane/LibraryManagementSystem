using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using MvcApp.Services;

namespace MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private IBookServices _bookService { get; set; }
        public HomeController(IBookServices bookServices)
        {
            _bookService = bookServices;
        }
        public IActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Home(string userName, string password)
        {
            var list = Models.User.user;
            if (list.FirstOrDefault(x => x.UserName == userName) != null &&
                list.FirstOrDefault(x => x.UserPassword == password) != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Index(string search)
        {
            var list = _bookService.GetAllBook();
            var result = list.FirstOrDefault(x => x.Title == search);
            if (result != null)
            {
                return View("index", new List<Book>() { result});
            }
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
