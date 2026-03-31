using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class ComplianceController : Controller
    {
        private readonly IComplianceService _complianceService;

        public ComplianceController(IComplianceService complianceService)
        {
            _complianceService = complianceService;
        }

        public IActionResult Index()
        {
            var records = _complianceService.GetAllRecords();
            return View(records);
        }

        public IActionResult Review(int id)
        {
            var record = _complianceService.GetRecordById(id);
            return View(record);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ComplianceRecord record)
        {
            record.Result = "Pending";
            record.InspectedBy = "";
            record.Remarks = "";
            _complianceService.AddRecord(record);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var record = _complianceService.GetRecordById(id);
            return View(record);
        }

        [HttpPost]
        public IActionResult Edit(ComplianceRecord record)
        {
            _complianceService.UpdateRecord(record);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _complianceService.DeleteRecord(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkPassed(int id)
        {
            _complianceService.MarkPassed(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MarkFailed(int id)
        {
            _complianceService.MarkFailed(id);
            return RedirectToAction("Index");
        }
    }
}
