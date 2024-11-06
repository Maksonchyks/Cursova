using Cursova.Models;
using Cursova.ViewModels;

namespace Cursova.Domain.Repositories.Abstract
{
    public interface ISupplierService
    {
        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(int supplierId);
        public List<Supplier> GetSupplier(SupplierViewModel filter);

        //8
        //отримати угоди і обсяг товарів по аайді постачальника
        List<Supplier> GetProductsBySupplier(int supplierId);
        //10
        //отримати постачальників по товару та обсяг проданого товару за період
        //List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount, DateTime startDate, DateTime endDate);
        //отримати постачальників по товару та обсязі проданого товару за весь час
        //List<Supplier> GetSuppliersByProductVolume(int productId, int totalAmount);



    }

}
