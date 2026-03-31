using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            var documents = _documentService.GetAllDocuments();
            return View(documents);
        }

        public IActionResult Verify(int id)
        {
            var doc = _documentService.GetDocumentById(id);
            return View(doc);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Document document)
        {
            document.Status = "Pending";
            document.VerifiedBy = "";
            _documentService.AddDocument(document);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var doc = _documentService.GetDocumentById(id);
            return View(doc);
        }

        [HttpPost]
        public IActionResult Edit(Document document)
        {
            _documentService.UpdateDocument(document);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _documentService.DeleteDocument(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Approve(int id)
        {
            _documentService.ApproveDocument(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Reject(int id)
        {
            _documentService.RejectDocument(id);
            return RedirectToAction("Index");
        }
    }
}
