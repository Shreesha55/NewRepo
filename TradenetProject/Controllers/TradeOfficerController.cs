using Microsoft.AspNetCore.Mvc;
using TradeNetProject.Models;
using TradeNetProject.Services;

namespace TradeNetProject.Controllers
{
    public class TradeOfficerController : Controller
    {
        private readonly ITradeOfficerService _officerService;
        private readonly ILicenseService _licenseService;
        private readonly ITransactionService _transactionService;
        private readonly IDocumentService _documentService;
        private readonly IMarketRecordService _marketService;
        private readonly IComplianceService _complianceService;

        public TradeOfficerController(
            ITradeOfficerService officerService,
            ILicenseService licenseService,
            ITransactionService transactionService,
            IDocumentService documentService,
            IMarketRecordService marketService,
            IComplianceService complianceService)
        {
            _officerService = officerService;
            _licenseService = licenseService;
            _transactionService = transactionService;
            _documentService = documentService;
            _marketService = marketService;
            _complianceService = complianceService;
        }

        public IActionResult Dashboard()
        {
            var officer = _officerService.GetCurrentOfficer();
            var licenses = _licenseService.GetAllLicenses();
            var transactions = _transactionService.GetAllTransactions();
            var documents = _documentService.GetAllDocuments();
            var markets = _marketService.GetAllRecords();
            var compliance = _complianceService.GetAllRecords();

            var vm = new DashboardViewModel
            {
                OfficerName = officer.FullName,
                TotalLicenses = licenses.Count,
                ApprovedLicenses = licenses.Count(l => l.Status == "Approved"),
                TotalTransactions = transactions.Count,
                CompletedTransactions = transactions.Count(t => t.Status == "Completed"),
                TotalDocuments = documents.Count,
                VerifiedDocuments = documents.Count(d => d.Status == "Verified"),
                TotalMarkets = markets.Count,
                ActiveMarkets = markets.Count(m => m.Status == "Active"),
                TotalCompliance = compliance.Count,
                PassedCompliance = compliance.Count(c => c.Result == "Passed")
            };

            return View(vm);
        }

        public IActionResult Profile()
        {
            var officer = _officerService.GetCurrentOfficer();
            return View(officer);
        }
    }
}
