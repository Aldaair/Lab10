using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC2.Models;

namespace WebApplicationMVC2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        public ActionResult Index()
        {
            List<CustomerModel> list = new List<CustomerModel>();
            CustomerBussiness ProductB = new CustomerBussiness();
            List<Customer> productos = ProductB.GetCustomers();

            //Convertir nuestro listado de entidades a listado de modelo
            //Entity => Model

            List<CustomerModel> models = new List<CustomerModel>();

            models = productos.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                Name = x.Name,
                Address = x.Address,
                Phone = x.Phone,
            }).ToList();

            return View(models);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
