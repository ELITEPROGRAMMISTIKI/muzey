using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using muzey.Data;
using muzey.Models;

namespace muzey.Pages
{
    public class AddYslModel : PageModel
    {
        private readonly muzey.Data.ApplicationDbContext _context;

        public AddYslModel(muzey.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Yslygi Yslygi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Yslygi.Add(Yslygi);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
