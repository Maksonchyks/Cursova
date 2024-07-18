using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class StockService : IStockService
    {
        private readonly AppDbContext _context;
        public StockService(AppDbContext context)
        {
            _context = context;
        }
        public List<Stock> GetProductDetailsBySupplier(int productId)
        {
            return _context.Stocks
                .Where(st => st.StockId == productId)
                .ToList();
        }

        
    }
}
