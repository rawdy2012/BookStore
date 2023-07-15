using Microsoft.AspNetCore.Mvc;

namespace Foto.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()
        {
            return View("First Action Method");
        }
    }
}
