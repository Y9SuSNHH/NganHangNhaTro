using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models
{
    [Table("motels")]
    public partial class Motel
    {
        [Key]
        public int id { get; set; }

        public string title { get; set; }

        public string description { get; set; }

        public string detail { get; set; }

        public string address { get; set; }

        public string price { get; set; }

        public string image { get; set; }

        public int created_by { get; set; }
    }
}
