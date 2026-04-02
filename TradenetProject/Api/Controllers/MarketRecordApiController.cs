using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketRecordApiController : ControllerBase
    {
        private readonly IMarketRecordService _marketRecordService;

        public MarketRecordApiController(IMarketRecordService marketRecordService)
        {
            _marketRecordService = marketRecordService;
        }

        /// <summary>
        /// Get all market records
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _marketRecordService.GetAllRecords();
            return Ok(records);
        }

        /// <summary>
        /// Get market record by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var record = _marketRecordService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Market record not found" });
            return Ok(record);
        }

        /// <summary>
        /// Create a new market record
        /// </summary>
        [HttpPost]
        public IActionResult Create(MarketRecord record)
        {
            _marketRecordService.AddRecord(record);
            return CreatedAtAction(nameof(GetById), new { id = record.RecordID }, record);
        }

        /// <summary>
        /// Update an existing market record
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, MarketRecord record)
        {
            var existing = _marketRecordService.GetRecordById(id);
            if (existing == null)
                return NotFound(new { message = "Market record not found" });

            record.RecordID = id;
            _marketRecordService.UpdateRecord(record);
            return Ok(new { message = "Market record updated successfully" });
        }

        /// <summary>
        /// Delete a market record
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var record = _marketRecordService.GetRecordById(id);
            if (record == null)
                return NotFound(new { message = "Market record not found" });
            
            _marketRecordService.DeleteRecord(id);
            return Ok(new { message = "Market record deleted successfully" });
        }
    }
}
