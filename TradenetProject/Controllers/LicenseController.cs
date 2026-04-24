using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class LicenseController : Controller
    {
        private readonly ILicenseService _licenseService;

        public LicenseController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        public IActionResult PendingLicenses()
        {
            var licenses = _licenseService.GetAllLicenses();
            return View(licenses);
        }

        public IActionResult Review(int id)
        {
            var license = _licenseService.GetLicenseById(id);
            return View(license);
        }
        // URL would look like: /Review/d27b9492-4f32-4f0f-8763-888484
        

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TradeLicense license)
        {
            license.Status = "Pending";
            _licenseService.AddLicense(license);
            return RedirectToAction("PendingLicenses");
        }

        public IActionResult Edit(int id)
        {
            var license = _licenseService.GetLicenseById(id);
            return View(license);
        }

        [HttpPost]
        public IActionResult Edit(TradeLicense license)
        {
            _licenseService.UpdateLicense(license);
            return RedirectToAction("PendingLicenses");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _licenseService.DeleteLicense(id);
            return RedirectToAction("PendingLicenses");
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            _licenseService.ApproveLicense(id);
            return RedirectToAction("PendingLicenses");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            _licenseService.RejectLicense(id);
            return RedirectToAction("PendingLicenses");
        }
    }
}
