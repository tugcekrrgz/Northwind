using Northwind.API.DTOs;
using Northwind.API.Models.Context;
using Northwind.API.Repositories;

namespace Northwind.API.Services
{
    public class ProductService : IProductRepository
    {
        private readonly NorthwindContext _context;

        public ProductService(NorthwindContext context)
        {
            _context = context;
        }

        public List<ProductDTO> GetAllProducts()
        {
            var products=from p in _context.Products 
                            join c in _context.Categories on p.CategoryId equals c.CategoryId
                            join s in _context.Suppliers on p.SupplierId equals s.SupplierId
                            select new ProductDTO
                            {
                                ProductId=p.ProductId,
                                ProductName=p.ProductName,
                                UnitPrice=p.UnitPrice,
                                UnitsInStock=p.UnitsInStock,
                                Category=c,
                                Supplier=s
                            };

            return products.ToList();
        }
    }
}
