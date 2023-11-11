using Business;
using Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC2.Models;

namespace WebApplicationMVC2.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductBusiness productBusiness = new ProductBusiness();
        // GET: ProductController
        public ActionResult Index()
        {
            List<ProductModel> list = new List<ProductModel>();
            List<Product> products = productBusiness.GetProducts();

            // Convertir nuestro listado de entidades a listado de modelo
            // Entity => Model
            List<ProductModel> models = products.Select(x => new ProductModel
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
            }).ToList();

            return View(models);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel productModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Convertir el modelo a entidad
                    Product product = new Product
                    {
                        Name = productModel.Name,
                        Price = productModel.Price,
                        Stock = productModel.Stock,
                        Active = true // Puedes establecer un valor predeterminado según tus necesidades
                    };

                    // Llamar al método de negocio para agregar el producto
                    productBusiness.AddProduct(product);

                    return RedirectToAction(nameof(Index));
                }

                return View(productModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            // Lógica para obtener el producto por su ID
            Product product = productBusiness.GetProductById(id);

            if (product == null)
            {
                return NotFound(); // Otra acción que maneje el caso cuando el producto no se encuentra
            }

            return View(product);
        }


        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Llamar al método de negocio para eliminar el producto
                productBusiness.DeleteProduct(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
    
}
