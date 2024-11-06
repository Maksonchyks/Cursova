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

        public void AddSalesDeal(SalesDeal salesDeal)
        {
            _context.SalesDeals.Add(salesDeal);
            _context.SaveChanges();
        }

        public void UpdateSalesDeal(SalesDeal salesDeal)
        {
            var existingSalesDeal = _context.SalesDeals.Find(salesDeal.DealId);
            if (existingSalesDeal != null)
            {
                existingSalesDeal.FrStockId = salesDeal.FrStockId;
                existingSalesDeal.FrSupplierId = salesDeal.FrSupplierId;
                existingSalesDeal.FrCustomerId = salesDeal.FrCustomerId;
                existingSalesDeal.QuantitySold = salesDeal.QuantitySold;
                _context.SaveChanges();
            }
        }

        public void DeleteSalesDeal(int DealId)
        {
            var salesDeal = _context.SalesDeals.Find(DealId);
            if (salesDeal != null)
            {
                _context.SalesDeals.Remove(salesDeal);
                _context.SaveChanges();
            }
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
