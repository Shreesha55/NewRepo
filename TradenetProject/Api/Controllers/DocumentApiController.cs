using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentApiController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentApiController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        /// <summary>
        /// Get all documents
        /// </summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var documents = _documentService.GetAllDocuments();
            return Ok(documents);
        }

        /// <summary>
        /// Get document by ID
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
                return NotFound(new { message = "Document not found" });
            return Ok(document);
        }

        /// <summary>
        /// Create a new document
        /// </summary>
        [HttpPost]
        public IActionResult Create(Document document)
        {
            _documentService.AddDocument(document);
            return CreatedAtAction(nameof(GetById), new { id = document.DocumentID }, document);
        }

        /// <summary>
        /// Update an existing document
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Document document)
        {
            var existing = _documentService.GetDocumentById(id);
            if (existing == null)
                return NotFound(new { message = "Document not found" });

            document.DocumentID = id;
            _documentService.UpdateDocument(document);
            return Ok(new { message = "Document updated successfully" });
        }

        /// <summary>
        /// Delete a document
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var document = _documentService.GetDocumentById(id);
            if (document == null)
                return NotFound(new { message = "Document not found" });
            
            _documentService.DeleteDocument(id);
            return Ok(new { message = "Document deleted successfully" });
        }
    }
}
