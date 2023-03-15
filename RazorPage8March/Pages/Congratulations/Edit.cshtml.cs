using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPage8March.Data;
using RazorPage8March.Models;

namespace RazorPage8March.Pages.Congratulations
{
    public class EditModel : PageModel
    {
        private readonly RazorPage8March.Data.RazorPage8MarchContext _context;

        public EditModel(RazorPage8March.Data.RazorPage8MarchContext context)
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

            var congratulation =  await _context.Congratulation.FirstOrDefaultAsync(m => m.Id == id);
            if (congratulation == null)
            {
                return NotFound();
            }
            Congratulation = congratulation;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Congratulation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CongratulationExists(Congratulation.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CongratulationExists(int id)
        {
          return (_context.Congratulation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
