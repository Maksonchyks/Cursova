using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using Cursova.ViewModels;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _context;
        public StockService(AppDbContext context)
        {
            _context = context;
        }
        public void AddStock(Stock stock)
        {
            _context.Stocks.Add(stock);
            _context.SaveChanges();
        }

        public void UpdateStock(Stock stock)
        {
            var existingStock = _context.Stocks.Find(stock.StockId);
            if (existingStock != null)
            {
                existingStock.ProductName = stock.ProductName;
                existingStock.FrSupplierId = stock.FrSupplierId;
                existingStock.Unit = stock.Unit;
                existingStock.Quantity = stock.Quantity;
                existingStock.PurchasePrice = stock.PurchasePrice;
                existingStock.SalePrice = stock.SalePrice;
                _context.SaveChanges();
            }
        }

        public void DeleteStock(int stockId)
        {
            var stock = _context.Stocks.Find(stockId);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                _context.SaveChanges();
            }
        }

        public List<Stock> GetStock(StockViewModel filter)
        {
            var query = _context.Stocks.AsQueryable();

            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(s => s.ProductName.Contains(filter.ProductName));
            }

            if (!string.IsNullOrEmpty(filter.Unit))
            {
                query = query.Where(s => s.Unit.Contains(filter.Unit));
            }

            if (filter.Quantity.HasValue)
            {
                query = query.Where(s => s.Quantity == filter.Quantity.Value);
            }

            if (filter.PurchasePrice.HasValue)
            {
                var roundedPurchasePrice = Math.Round(filter.PurchasePrice.Value);
                query = query.Where(s => Math.Round(s.PurchasePrice) == roundedPurchasePrice);
            }

            if (filter.SalePrice.HasValue)
            {
                var roundedSalePrice = Math.Round(filter.SalePrice.Value);
                query = query.Where(s => Math.Round(s.SalePrice) == roundedSalePrice);
            }

            return query.ToList();
        }


        public List<Stock> GetProductDetailsBySupplier(int productId)
        {
            return _context.Stocks
                .Where(st => st.StockId == productId)
                .ToList();
        }

        
    }
}
