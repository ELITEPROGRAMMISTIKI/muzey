using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using muzey.Data;
using muzey.Models;

namespace muzey.Pages
{
    public class catalogModel : PageModel
    {
        public List<Yslygi> yslygi;
        private ApplicationDbContext _context;
        public catalogModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            yslygi = _context.Yslygi.ToList();
        }
    }
}
