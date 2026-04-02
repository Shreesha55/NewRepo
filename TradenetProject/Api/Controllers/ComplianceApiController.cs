using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComplianceApiController : ControllerBase
    {
        private readonly IComplianceService _complianceService;

        public ComplianceApiController(IComplianceService complianceService)
        {
            _complianceService = complianceService;
        }

        /// <summary>
        /// Get all compliance records
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _complianceService.GetAllRecords();
            return Ok(records);
        }

        /// <summary>
        /// Get compliance record by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _complianceService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Compliance record not found" });
            return Ok(record);
        }

        /// <summary>
        /// Create a new compliance record
        /// </summary>
        [HttpPost]
        public IActionResult Create(ComplianceRecord record)
        {
            record.Result = "Pending";
            record.InspectedBy = "";
            record.Remarks = "";
            _complianceService.AddRecord(record);
            return CreatedAtAction(nameof(GetById), new { id = record.ComplianceID }, record);
        }

        /// <summary>
        /// Update an existing compliance record
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, ComplianceRecord record)
        {
            var existing = _complianceService.GetRecordById(id);
            if (existing == null)
                return NotFound(new { message = "Compliance record not found" });

            record.ComplianceID = id;
            _complianceService.UpdateRecord(record);
            return Ok(new { message = "Compliance record updated successfully" });
        }

        /// <summary>
        /// Delete a compliance record
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var record = _complianceService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Compliance record not found" });
            
            _complianceService.DeleteRecord(id);
            return Ok(new { message = "Compliance record deleted successfully" });
        }

        /// <summary>
        /// Mark a compliance record as passed
        /// </summary>
        [HttpPost("{id}/passed")]
        public IActionResult MarkPassed(int id)
        {
            var record = _complianceService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Compliance record not found" });
            
            _complianceService.MarkPassed(id);
            return Ok(new { message = "Compliance record marked as passed" });
        }

        /// <summary>
        /// Mark a compliance record as failed
        /// </summary>
        [HttpPost("{id}/failed")]
        public IActionResult MarkFailed(int id)
        {
            var record = _complianceService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Compliance record not found" });
            
            _complianceService.MarkFailed(id);
            return Ok(new { message = "Compliance record marked as failed" });
        }
    }
}
