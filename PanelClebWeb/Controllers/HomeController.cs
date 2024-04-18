using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using PanelClebWeb.Models;
using System.Diagnostics;


namespace PanelClebWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        BotSettingManager botSettingManager = new BotSettingManager(new EfBotSettingDal());

        public IActionResult Index()
        {
            var botsettings = botSettingManager.GetById(1);
            var botStatus = botsettings.BotStatus;
            ViewBag.BotStatus = botStatus;
            return View();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

      


       
    }
}
