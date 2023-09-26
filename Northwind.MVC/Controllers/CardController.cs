using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class CardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
