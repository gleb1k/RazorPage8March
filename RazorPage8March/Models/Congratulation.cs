using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPage8March.Models

{
    public class Congratulation
    {
        public int Id { get; set; }
        [Display(Name = "Release Date")]
        public string ImgUrl { get; set; }
        public string Description { get; set; }
    }
}
