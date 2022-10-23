using System.ComponentModel.DataAnnotations;

namespace Word_puzzle.Models
{
    public class Argument
    {
        [StringLength(4, ErrorMessage = "Max Length is 4")] //TODO
        public string StartWord { get; set; }
        [MaxLength(4)]
        public string EndWord { get; set; }
        public string ResultFile { get; set; }
    }
}
