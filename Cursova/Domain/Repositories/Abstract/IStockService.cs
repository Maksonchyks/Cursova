using Cursova.Models;

namespace Cursova.Domain.Repositories.Abstract
{
    public interface IStockService
    {
        //2
        ///*відомість про обсяг і ціну товару по всіх постачальниках без п*/
        List<Stock> GetProductDetailsBySupplier(int productId);
    }

}
