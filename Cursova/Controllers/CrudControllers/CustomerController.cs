using Cursova.Models;
using Microsoft.AspNetCore.Mvc;
using Cursova.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize]

    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult CustomerIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerService.AddCustomer(customer);
            }
            return RedirectToAction("CrudIndex", "Crud");
            
        }
        [HttpPost]
        public IActionResult Update(Customer customer) 
        {
            if(ModelState.IsValid)
            {
                _customerService.UpdateCustomer(customer);
            }
            return RedirectToAction("CrudIndex", "Crud");

        }
        [HttpPost]
        public IActionResult Delete(int CustomerId)
        {
            if (ModelState.IsValid)
            {
                _customerService.DeleteCustomer(CustomerId);
            }
            return RedirectToAction("CrudIndex", "Crud");
        }
    }
}
