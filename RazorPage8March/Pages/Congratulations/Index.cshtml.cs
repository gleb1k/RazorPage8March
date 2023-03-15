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
    public class IndexModel : PageModel
    {
        private readonly RazorPage8March.Data.RazorPage8MarchContext _context;

        public IndexModel(RazorPage8March.Data.RazorPage8MarchContext context)
        {
            _context = context;
        }

        public IList<Congratulation> Congratulation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Congratulation != null)
            {
                Congratulation = await _context.Congratulation.ToListAsync();
            }
        }
    }
}
