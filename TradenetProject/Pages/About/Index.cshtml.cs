using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TradenetProject.Pages.About
{
    public class IndexModel : PageModel
    {
        public string Version { get; set; }
        public string Framework { get; set; }
        public string Architecture { get; set; }

        public void OnGet()
        {
            Version = "1.0.0";
            Framework = ".NET 10";
            Architecture = "MVC + Razor Pages";
        }
    }
}
