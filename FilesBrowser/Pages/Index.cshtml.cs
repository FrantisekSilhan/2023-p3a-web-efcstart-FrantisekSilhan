using FilesBrowser.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilesBrowser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
