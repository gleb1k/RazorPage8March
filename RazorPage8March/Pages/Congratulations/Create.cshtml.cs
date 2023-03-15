using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPage8March.Data;
using RazorPage8March.Models;

namespace RazorPage8March.Pages.Congratulations
{
    public class CreateModel : PageModel
    {
        private readonly RazorPage8March.Data.RazorPage8MarchContext _context;

        public CreateModel(RazorPage8March.Data.RazorPage8MarchContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Congratulation Congratulation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Congratulation == null || Congratulation == null)
            {
                return Page();
            }

            _context.Congratulation.Add(Congratulation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
