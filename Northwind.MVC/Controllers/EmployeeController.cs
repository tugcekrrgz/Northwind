using Microsoft.AspNetCore.Mvc;

namespace Northwind.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
