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
        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
        }

        public void UpdateSupplier(Supplier supplier)
        {
            var existingSupplier = _context.Suppliers.Find(supplier.SupplierId);
            if (existingSupplier != null)
            {
                existingSupplier.SupplierName = supplier.SupplierName;
                existingSupplier.Address = supplier.Address;
                existingSupplier.Phone = supplier.Phone;
                _context.SaveChanges();
            }
        }
        public void DeleteSupplier(int supplierId)
        {
            var supplier = _context.Suppliers.Find(supplierId);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
        //8
        public List<Supplier> GetProductsBySupplier(int supplierId)
        {
            return _context.Suppliers
                .Where(s => s.SupplierId == supplierId)
                .ToList();
        }

        //10
        /*public List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount, DateTime startDate, DateTime endDate)
        {
            return _context.Suppliers
                .Where(s => s.Stocks.Any(st => st.SalesDeal.TotalAmount >= totalAmount
                                                && st.SalesDeal.OrderDate >= startDate
                                                && st.SalesDeal.OrderDate <= endDate
                                                && st.StockId == productId))
                .ToList();
        }*/

        /*public List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount)
        {
            return _context.Suppliers
                .Where(s => s.Stocks.Any(st => st.SalesDeal.TotalAmount >= totalAmount
                                                && st.StockId == productId))
                .ToList();
        }*/
    }
}
