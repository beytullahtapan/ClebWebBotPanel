using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PanelClebWeb.Controllers
{
    public class SafeBoxController : Controller
    {
        SafeBoxManager safeBoxManager = new SafeBoxManager(new EfSafeBoxDal());
        public IActionResult Index()
        {
            var values = safeBoxManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Create(SafeBox s)
        {
            safeBoxManager.Insert(s);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            
            var value = safeBoxManager.GetById(id);
            if (value != null) {
                return View(value);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(SafeBox s)
        {
            var value = safeBoxManager.GetById(s.Id);
            if (value != null)
            {
                safeBoxManager.Update(s);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var value = safeBoxManager.GetById(id);
            if (value != null)
            {
                safeBoxManager.Delete(value);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
