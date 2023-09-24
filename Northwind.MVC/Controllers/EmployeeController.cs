using Microsoft.AspNetCore.Mvc;
using Northwind.API.Repositories;

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
