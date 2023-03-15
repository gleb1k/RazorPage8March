using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPage8March.Models;

namespace RazorPage8March.Data
{
    public class RazorPage8MarchContext : DbContext
    {
        public RazorPage8MarchContext (DbContextOptions<RazorPage8MarchContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPage8March.Models.Congratulation> Congratulation { get; set; } = default!;
    }
}
