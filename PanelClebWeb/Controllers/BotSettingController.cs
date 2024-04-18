using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace PanelClebWeb.Controllers
{
    public class BotSettingController : Controller
    {
        BotSettingManager botSettingManager = new BotSettingManager(new EfBotSettingDal());
        [HttpGet]
        public IActionResult Index()
        {
            var values = botSettingManager.GetById(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(BotSetting p)
        {
            var values = botSettingManager.GetById(1);
            if(values != null)
            {
                values.StockControlStatus = p.StockControlStatus;
                values.StockControlTime = p.StockControlTime;
                values.StokControlChannel = p.StokControlChannel;
                values.StockUpdateTime = p.StockUpdateTime;
                values.StockUpdateChannel = p.StockUpdateChannel;
                values.apiKey = p.apiKey;
                values.apiSecret = p.apiSecret;
                values.SupplerId = p.SupplerId;
                values.StockCount = p.StockCount;
                values.StockCountStatus = p.StockCountStatus;
                botSettingManager.Update(values);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

    }
}
