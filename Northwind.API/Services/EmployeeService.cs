using Northwind.API.DTOs;
using Northwind.API.Models.Context;
using Northwind.API.Repositories;

namespace Northwind.API.Services
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly NorthwindContext _context;

        public EmployeeService(NorthwindContext context) 
        {
            _context = context;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var employees = _context.Employees.Select(x => new EmployeeDTO
            {
                Id = x.EmployeeId,
                Firstname = x.FirstName,
                Lastname = x.LastName,
                Title = x.Title
            }).ToList();

            return employees;
        }

        public SalesDetailsDTO GetSalesDetails(int id)
        {
            var details = _context.Employees.Where(x => x.EmployeeId == id).Select(x => new SalesDetailsDTO
            {
                Firstname = x.FirstName,
                Lastname= x.LastName
            }).FirstOrDefault();

            details.TotalSales = _context.Orders.Where(x => x.EmployeeId == id).Count();

            return details;
        }
    }
}
