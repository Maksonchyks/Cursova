using Cursova.Models;
using Microsoft.AspNetCore.Mvc;
using Cursova.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Cursova.Controllers.CrudControllers
{
    [Authorize(Roles = "Owner,Admin,Operator")]

    public class CustomerController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICustomerService _customerService;
        public CustomerController
        (   ICustomerService customerService,
            AppDbContext context
        )
        {
            _customerService = customerService;
            _context = context;
        }
        public IActionResult CustomerIndex()
        {
            ViewData["Customers"] = _context.Customers.ToList();
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
