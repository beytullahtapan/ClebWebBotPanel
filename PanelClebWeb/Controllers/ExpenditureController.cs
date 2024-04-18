using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PanelClebWeb.Controllers
{
    public class ExpenditureController : Controller
    {
        ExpenditureManager expenditureManager = new ExpenditureManager(new EfExpenditureDal());
        SafeBoxManager safeBoxManager = new SafeBoxManager(new EfSafeBoxDal());
        public IActionResult Index()
        {
            var values = expenditureManager.GetList();
            ViewBag.SafeBoxes = safeBoxManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.SafeBoxes = safeBoxManager.GetList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Expenditure p)
        {
            var safeBox = safeBoxManager.GetById(p.SafeBoxId);
            safeBox.SafeBoxAmount -= p.ExpenditureAmount;
            safeBoxManager.Update(safeBox);
            p.SafeBoxTotal = safeBox.SafeBoxAmount;
            expenditureManager.Insert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var value = expenditureManager.GetById(id);
            if (value == null)
            {
                   return RedirectToAction("Index");
            }
            ViewBag.SafeBoxes = safeBoxManager.GetList();
            return View(value);
        }
        [HttpPost]
        public IActionResult Edit(Expenditure p)
        {
            var value = expenditureManager.GetById(p.Id);
            if (value == null)
            {
                return RedirectToAction("Index");
            }
            var safeBox = safeBoxManager.GetById(p.SafeBoxId);
            safeBox.SafeBoxAmount += value.ExpenditureAmount;
            safeBoxManager.Update(safeBox);

            value.ExpenditureName = p.ExpenditureName;
            value.ExpenditureAmount = p.ExpenditureAmount;
            value.SafeBoxId = p.SafeBoxId;
            safeBox.SafeBoxAmount -= p.ExpenditureAmount; 
            value.SafeBoxTotal = safeBox.SafeBoxAmount;
            safeBoxManager.Update(safeBox);
            expenditureManager.Update(value);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var value = expenditureManager.GetById(id);
            if (value == null)
            {
                return RedirectToAction("Index");
            }
            var safeBox = safeBoxManager.GetById(value.SafeBoxId);
            safeBox.SafeBoxAmount += value.ExpenditureAmount;
            safeBoxManager.Update(safeBox);
            expenditureManager.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
