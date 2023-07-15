using Microsoft.AspNetCore.Mvc;

namespace Foto.BookStore.Controllers
{
    public class HomeController:Controller
    {
        public string Index()
        {
            return "First Action Method";//View("First Action Method");
        }
    }
}
