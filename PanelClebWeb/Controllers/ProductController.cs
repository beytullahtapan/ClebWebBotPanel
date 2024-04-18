using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace PanelClebWeb.Controllers
{
    public class ProductController : Controller
    {
        ProductManager productManager = new ProductManager(new EfProductDal());
        [HttpGet]
        public IActionResult Index(int? page)
        {
            const int pageSize = 20;
            int pageNumber = page ?? 1;

            var products = productManager.TGetList().ToPagedList(pageNumber, pageSize);

            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                productManager.TAdd(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var values = productManager.TGetById(id);
            if(values == null)
            {
                return RedirectToAction("Index");
            }
            return View(values);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                productManager.TUpdate(product);
                return RedirectToAction("Index");
            }       
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var values = productManager.TGetById(id);
            if(values == null)
            {
                return RedirectToAction("Index");
            }
            productManager.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
