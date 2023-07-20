using System.ComponentModel.DataAnnotations;

namespace NganHangNhaTro.Models.Views
{
    public class MotelView
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string detail { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public IFormFile image { get; set; }
    }
}