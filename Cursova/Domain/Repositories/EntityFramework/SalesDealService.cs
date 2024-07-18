using Cursova.Domain.Repositories.Abstract;
using Cursova.Models;
using System.Linq;

namespace Cursova.Domain.Repositories.EntityFramework
{
    public class SalesDealService : ISalesDealService
    {
        private readonly AppDbContext _context;
        public SalesDealService(AppDbContext context) {
            _context = context;
        }
        
        //4
        public List<SalesDeal> GetDealsByProductAndSupplier(int productId, int supplierId, DateTime startDate, DateTime endDate)
        {
            return _context.SalesDeals
                .Where(sd => sd.FrStockId == productId
                            && sd.OrderDate >= startDate
                            && sd.OrderDate <= endDate
                            && sd.FrSupplierId == supplierId) 
                .ToList();
        }

        public List<SalesDeal> GetDealsByProductAndSupplier(int productId, int supplierId)
        {
            return _context.SalesDeals
                .Where(sd => sd.FrStockId == productId
                            && sd.FrSupplierId == supplierId)
                .ToList();
        }

        //5
        public List<SalesDeal> GetSalesDealByDealNumber(int dealId)
        {
            return _context.SalesDeals
                .Where(sd =>sd.DealId == dealId)
                .ToList();

        }

        //6
        public List<SalesDeal> GetProductSalesVolume(int productId, DateTime startDate, DateTime endDate)
        {
            return _context.SalesDeals
                .Where(sd => sd.FrStockId == productId
                            && sd.OrderDate >= startDate
                            && sd.OrderDate <= endDate)
                .ToList();
        }

        //7
        /*public decimal GetWarehouseProfitabilityAsync(DateTime? startDate, DateTime? endDate, decimal totalAmount)
        {
            throw new NotImplementedException();
        }*/
    }
}
