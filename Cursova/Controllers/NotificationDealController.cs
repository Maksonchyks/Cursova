using Cursova.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cursova.Controllers
{
    [Authorize(Roles ="Owner,Admin,Operator")]
    public class NotificationDealController : Controller
    {
        private readonly AppDbContext _context;
        public NotificationDealController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult DealIndex()
        {
            return View();
        }
        
        //1 - 
        public IActionResult ActiveCustomers()
        {
            var customers = _context.SalesDeals
                .GroupBy(d => d.Customer.CustomerName)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalPurchases = g.Count(),
                    TotalAmountSpent = g.Sum(d => d.TotalAmount)
                })
                .OrderByDescending(c => c.TotalPurchases)
                .Take(5)
                .ToList();

            return View(customers);
        }
        //2 - 
        public IActionResult ProductVolumeAndPricesBySuppliers(string productName)
        {
            var suppliers = _context.Stocks
                .Where(s => s.ProductName == productName)
                .Select(s => new
                {
                    ProductName = s.ProductName,
                    SupplierName = s.Supplier.SupplierName,
                    Quantity = s.Quantity,
                    SalePrice = s.SalePrice
                }).ToList();

            return View(suppliers);
        }

        //3
        public IActionResult CustomersByProductAndPeriod(string productName, DateTime? startDate, DateTime? endDate, string supplierName)
        {
            var query = _context.SalesDeals
                .Where(d => d.Stock.ProductName == productName);

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(d => d.OrderDate >= startDate && d.OrderDate <= endDate);
            }
            if (!string.IsNullOrEmpty(supplierName))
            {
                query = query.Where(d => d.Supplier.SupplierName == supplierName);
            }
            var result = query
                .Select(d => new
                {
                    ProductName = d.Stock.ProductName,
                    CustomerName = d.Customer.CustomerName,
                    CustomerAddress = d.Customer.Address,
                    CustomerPhone = d.Customer.Phone,
                    Quantity = d.QuantitySold,
                    PurchaseDate = d.OrderDate
                }).ToList();

            return View(result);
        }

        //4
        public IActionResult ProductSuppliesBySupplierAndPeriod(string productName, DateTime? startDate, DateTime? endDate, string supplierName)
        {
            var query = _context.SalesDeals
                .Where(d => d.Stock.ProductName == productName);

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(d => d.OrderDate >= startDate && d.OrderDate <= endDate);
            }
            if (!string.IsNullOrEmpty(supplierName))
            {
                query = query.Where(d => d.Supplier.SupplierName == supplierName);
            }
            var result = query
                .Select(d => new
                {
                    ProductName = d.Stock.ProductName,
                    CustomerName = d.Customer.CustomerName,
                    ProductQuantity = d.Stock.Quantity,
                    ProductPurchasePrice = d.Stock.PurchasePrice,
                    ProductSalePrice = d.Stock.SalePrice,
                    Quantity = d.QuantitySold,
                    PurchaseDate = d.OrderDate
                }).ToList();

            return View(result);
        }

        //5
        public IActionResult SuppliesByAgreement(int DealId)
        {
            var supplies = _context.SalesDeals
                .Where(d => d.DealId == DealId)
                .Select(d => new
                {
                    DealId = d.DealId,
                    ProductName = d.Stock.ProductName,
                    SupplierName = d.Supplier.SupplierName,
                    CustomerName= d.Customer.CustomerName,
                    Quantity = d.QuantitySold,
                    TotalAmount = d.TotalAmount
                }).ToList();

            return View(supplies);
        }

        //6
        public IActionResult SalesVolumeByProductAndPeriod(string productName, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.SalesDeals
                .Where(d => d.Stock.ProductName == productName);

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(d => d.OrderDate >= startDate && d.OrderDate <= endDate);
            }

            var result = query
                .GroupBy(d => d.Stock.Supplier.SupplierName)
                .Select(g => new
                {
                    SupplierName = g.Key,
                    TotalQuantity = g.Sum(d => d.QuantitySold),
                    TotalRevenue = g.Sum(d => d.TotalAmount)
                }).ToList();

            return View(result);
        }
        //7
        public IActionResult WarehouseProfitability(DateTime? startDate, DateTime? endDate)
        {
            // Накладні витрати (оренда + комунальні послуги)
            decimal rentCost = 5000;
            decimal utilitiesCost = 5000;
            decimal overheadCosts = rentCost + utilitiesCost;

            // Формуємо запит для фільтрації продажів за періодом
            var salesQuery = _context.SalesDeals.AsQueryable();
            if (startDate.HasValue && endDate.HasValue)
            {
                salesQuery = salesQuery.Where(d => d.OrderDate >= startDate && d.OrderDate <= endDate);
            }

            // Розрахунок загальної суми продажів
            decimal totalSalesVolume = salesQuery.Sum(d => d.TotalAmount);

            // Розрахунок початкової вартості проданих продуктів
            decimal totalPurchaselCost = salesQuery
                .Sum(d => d.QuantitySold * d.Stock.PurchasePrice); 

            // Рентабельність складу
            decimal profit = totalSalesVolume - totalPurchaselCost;
            decimal profitabilityRatio = overheadCosts != 0 ? profit / overheadCosts : 0;

            // Підготовка даних для представлення
            var result = new
            {
                TotalSalesVolume = totalSalesVolume,
                TotalPurchaselCost = totalPurchaselCost,
                Profit = profit,
                OverheadCosts = overheadCosts,
                ProfitabilityRatio = profitabilityRatio,
                RentCost = rentCost,
                UtilitiesCost = utilitiesCost
            };

            return View(result);
        }
        //8
        public IActionResult SupplierInventory(string supplierName)
        {
            var inventory = _context.Stocks
                .Where(s => s.Supplier.SupplierName == supplierName)
                .Select(s => new
                {
                    SupplierName = s.Supplier.SupplierName,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    PurchasePrice = s.PurchasePrice,
                    SalePrice = s.SalePrice
                }).ToList();

            return View(inventory);
        }
        //9
        public IActionResult CustomersByProductAndVolume(string productName, DateTime? startDate, DateTime? endDate, int? minQuantity)
        {
            var query = _context.SalesDeals
                .Where(d => d.Stock.ProductName == productName);

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(d => d.OrderDate >= startDate && d.OrderDate <= endDate);
            }

            if (minQuantity.HasValue)
            {
                query = query.Where(d => d.QuantitySold >= minQuantity);
            }

            var result = query
                .GroupBy(d => d.Customer.CustomerName)
                .Select(g => new
                {
                    CustomerName = g.Key,
                    TotalPurchases = g.Count()
                }).ToList();

            var totalCustomers = result.Count;

            return View(new { Customers = result, TotalCustomers = totalCustomers });
        }
        //10
        public IActionResult SuppliersByProductAndVolume(string productName, int? minQuantity, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Stocks
                .Where(s => s.ProductName == productName);

            if (minQuantity.HasValue)
            {
                query = query.Where(s => s.Quantity >= minQuantity);
            }

            if (startDate.HasValue && endDate.HasValue)
            {
                query = query.Where(s => s.SalesDeal.Any(d => d.OrderDate >= startDate && d.OrderDate <= endDate));
            }

            var result = query
                .GroupBy(s => s.Supplier.SupplierName)
                .Select(g => new
                {
                    SupplierName = g.Key,
                    TotalSupplied = g.Sum(s => s.Quantity)
                }).ToList();

            var totalSuppliers = result.Count;

            return View(new { Suppliers = result, TotalSuppliers = totalSuppliers });
        }
    }
}
