using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class MarketRecordController : Controller
    {
        private readonly IMarketRecordService _marketService;

        public MarketRecordController(IMarketRecordService marketService)
        {
            _marketService = marketService;
        }

        public IActionResult Index()
        {
            var records = _marketService.GetAllRecords();
            return View(records);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MarketRecord record)
        {
            _marketService.AddRecord(record);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var record = _marketService.GetRecordById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(MarketRecord record)
        {
            _marketService.UpdateRecord(record);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _marketService.DeleteRecord(id);
            return RedirectToAction("Index");
        }
    }
}
