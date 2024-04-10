using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerHelper CustomerHelper;

        public CustomerController(ICustomerHelper customerHelper)
        {
            CustomerHelper = customerHelper;
        }


        // GET: CustomerController
        public ActionResult Index()
        {
            List<CustomerViewModel> lista = CustomerHelper.GetCustomers();
            return View(lista);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            CustomerViewModel customer = CustomerHelper.GetCustomer(id);
            return View(customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerViewModel customer)
        {
            try
            {
                CustomerHelper.AddCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {

            CustomerViewModel customer = CustomerHelper.GetCustomer(id);
            return View(customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel customer)
        {
            try
            {
                CustomerHelper.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {

            CustomerViewModel customer = CustomerHelper.GetCustomer(id);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CustomerViewModel customer)
        {
            try
            {
                CustomerHelper.DeleteCustomer(customer.CustomerId);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}