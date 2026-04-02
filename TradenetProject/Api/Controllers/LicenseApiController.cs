using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LicenseApiController : ControllerBase
    {
        private readonly ILicenseService _licenseService;

        public LicenseApiController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        /// <summary>
        /// Get all trade licenses
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var licenses = _licenseService.GetAllLicenses();
            return Ok(licenses);
        }

        /// <summary>
        /// Get trade license by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var license = _licenseService.GetLicenseById(id);
            if (license == null)
                return NotFound(new { message = "License not found" });
            return Ok(license);
        }

        /// <summary>
        /// Create a new trade license
        /// </summary>
        [HttpPost]
        public IActionResult Create(TradeLicense license)
        {
            _licenseService.AddLicense(license);
            return CreatedAtAction(nameof(GetById), new { id = license.LicenseID }, license);
        }

        /// <summary>
        /// Update an existing trade license
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, TradeLicense license)
        {
            var existing = _licenseService.GetLicenseById(id);
            if (existing == null)
                return NotFound(new { message = "License not found" });

            license.LicenseID = id;
            _licenseService.UpdateLicense(license);
            return Ok(new { message = "License updated successfully" });
        }

        /// <summary>
        /// Delete a trade license
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var license = _licenseService.GetLicenseById(id);
            if (license == null)
                return NotFound(new { message = "License not found" });
            
            _licenseService.DeleteLicense(id);
            return Ok(new { message = "License deleted successfully" });
        }
    }
}
