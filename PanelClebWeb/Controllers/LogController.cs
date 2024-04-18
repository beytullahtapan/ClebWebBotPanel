using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PanelClebWeb.Controllers
{
    public class LogController : Controller
    {
        LogEntryManager logEntryManager = new LogEntryManager(new EfLogEntryDal());

        public IActionResult Index()
        {
            var allValues = logEntryManager.GetList();
            DateTime last24Hours = DateTime.Now.AddHours(-24);
            var oldValues = allValues.Where(entry => entry.Date < last24Hours).ToList();

            foreach (var entry in oldValues)
            {
                logEntryManager.Delete(entry);
            }

            return View(allValues);
        }

    }
}
