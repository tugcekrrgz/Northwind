using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.API.DTOs;
using Northwind.API.Models.Context;
using Northwind.API.Repositories;

namespace Northwind.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) 
        {
            _employeeRepository = employeeRepository;
        }


        public IActionResult Get()
        {
            var employees = _employeeRepository.GetEmployees();

            return Ok(employees);
        }

    }
}
