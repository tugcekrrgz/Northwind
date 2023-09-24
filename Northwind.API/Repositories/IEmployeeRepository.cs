using Northwind.API.DTOs;

namespace Northwind.API.Repositories
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> GetEmployees();

        SalesDetailsDTO GetSalesDetails(int id);
    }
}
