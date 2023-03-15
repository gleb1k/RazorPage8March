using Microsoft.EntityFrameworkCore;
using RazorPage8March.Data;
using System.Drawing;


namespace RazorPage8March.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPage8MarchContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPage8MarchContext>>()))
            {
                if (context == null || context.Congratulation == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Congratulation.Any())
                {
                    return;   // DB has been seeded
                }

                context.Congratulation.AddRange(
                    new Models.Congratulation
                    {
                        ImgUrl = "aboba",
                        Description = "Говнюк"
                    },
                    new Models.Congratulation
                    {
                        ImgUrl = "aboba",
                        Description = "Говнюк"
                    }, new Models.Congratulation
                    {
                        ImgUrl = "aboba",
                        Description = "Говнюк"
                    } , new Models.Congratulation
                    {
                        ImgUrl = "aboba",
                        Description = "Говнюк"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
