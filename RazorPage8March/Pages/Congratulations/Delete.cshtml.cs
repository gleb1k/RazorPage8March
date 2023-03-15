using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPage8March.Data;
using RazorPage8March.Models;

namespace RazorPage8March.Pages.Congratulations
{
    public class DeleteModel : PageModel
    {
        private readonly RazorPage8March.Data.RazorPage8MarchContext _context;

        public DeleteModel(RazorPage8March.Data.RazorPage8MarchContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Congratulation Congratulation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Congratulation == null)
            {
                return NotFound();
            }

            var congratulation = await _context.Congratulation.FirstOrDefaultAsync(m => m.Id == id);

            if (congratulation == null)
            {
                return NotFound();
            }
            else 
            {
                Congratulation = congratulation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Congratulation == null)
            {
                return NotFound();
            }
            var congratulation = await _context.Congratulation.FindAsync(id);

            if (congratulation != null)
            {
                Congratulation = congratulation;
                _context.Congratulation.Remove(Congratulation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
