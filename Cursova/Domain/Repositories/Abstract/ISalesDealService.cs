using Cursova.Models;

namespace Cursova.Domain.Repositories.Abstract
{
    public interface ISalesDealService
    {
        void AddSalesDeal(SalesDeal salesDeal);
        void UpdateSalesDeal(SalesDeal salesDeal);
        void DeleteSalesDeal(int salesDealId);

        List<Customer> GetMostActiveCustomers();


        //4

        //відомість про поставку за айді товару, за постачальником за період
        List<SalesDeal> GetDealsByProductAndSupplier(int productId, int supplierId, DateTime startDate, DateTime endDate);

        //відомість про поставку за айді товару, за постачальником за увесь час поставок 
        List<SalesDeal> GetDealsByProductAndSupplier(int productId, int supplierId);
        //5
        //відомість про поставку за номером угоди
        List<SalesDeal> GetSalesDealByDealNumber(int dealId);
        //6
        // відомість про обсяг продажів за айді товару, за деякий період
        List<SalesDeal> GetProductSalesVolume(int dealId, DateTime startDate, DateTime endDate);

        //7
        // собівартість складу за період по кількості проданого
        //decimal GetWarehouseProfitabilityAsync(DateTime? startDate, DateTime? endDate, decimal totalAmount);

    }

}
