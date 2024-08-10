using Cursova.Models;

namespace Cursova.Domain.Repositories.Abstract
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

        //1
        //відомість про найактивніших покупців
        List<Customer> GetMostActiveCustomer();

        //3
        //за період по конкретному пост
        List<Customer> GetCustomersByProductAndPeriod(int productId, DateTime startDate, DateTime endDate, int supplierId);
        //за період по всіх пост
        List<Customer> GetCustomersByProductAndPeriod(int productId, DateTime start, DateTime end);
        //за весь час по конкретному пост
        List<Customer> GetCustomersByProductAndPeriod(int productId, int supplierId);
        //за весь час по всіх пост
        List<Customer> GetCustomersByProductAndPeriod(int productId);

        //9
        // покупці по айді товару + виводити покупців які робили більше заданої кількості покупок
        //List<Customer> GetCustomersByProductVolume(int productId, DateTime startDate, DateTime endDate, int? salesDeal);

    }


}
