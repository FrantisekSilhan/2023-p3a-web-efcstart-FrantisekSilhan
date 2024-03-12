using FilesBrowser.Data;
using FilesBrowser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FilesBrowser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DatabaseContext _context;

        public Folder Folder { get; set; }

        public IndexModel(ILogger<IndexModel> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet(Guid folder)
        {
            if (folder == Guid.Empty) {
                Folder = _context.Folders.FirstOrDefault(f => f.Name == "Root");
            }
            else {
                Folder = _context.Folders.FirstOrDefault(f => f.FolderId == folder);
            }
            Folder.Folders = _context.Folders.Where(f => f.ParentFolderId == Folder.FolderId).ToList();
        }
    }
}
