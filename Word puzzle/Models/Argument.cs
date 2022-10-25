using System.ComponentModel.DataAnnotations;

namespace WordPuzzle.Models
{
    public class Argument
    {
        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string StartWord { get; set; }

        [Required]
        [StringLength(4,  MinimumLength = 4)]
        public string EndWord { get; set; }

        [Required]
        public string ResultFile { get; set; }
    }
}
