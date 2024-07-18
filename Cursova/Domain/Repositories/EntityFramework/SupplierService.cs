using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class SupplierService : ISupplierService
    {
        private readonly AppDbContext _context;
        public SupplierService(AppDbContext context)
        {
            _context = context;
        }
        //8
        public List<Supplier> GetProductsBySupplier(int supplierId)
        {
            return _context.Suppliers
                .Where(s => s.SupplierId == supplierId)
                .ToList();
        }

        //10
        public List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount, DateTime startDate, DateTime endDate)
        {
            return _context.Suppliers
                .Where(s => s.Stocks.Any(st => st.SalesDeal.TotalAmount >= totalAmount
                                                && st.SalesDeal.OrderDate >= startDate
                                                && st.SalesDeal.OrderDate <= endDate
                                                && st.StockId == productId))
                .ToList();
        }

        public List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount)
        {
            return _context.Suppliers
                .Where(s => s.Stocks.Any(st => st.SalesDeal.TotalAmount >= totalAmount
                                                && st.StockId == productId))
                .ToList();
        }
    }
}
