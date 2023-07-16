using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models
{
    [Table("motels")]
    public partial class Motel
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
        public string image { get; set; }

        [Required]
        public string created_by { get; set; }
    }
}
