using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models
{
    [Table("users")]
    public partial class User
    {
        [Key]
        public int id { get; set; }

        public string username { get; set; }

        public string phone_number { get; set; }
        public string? email { get; set; }

        public string password { get; set; }
    }
}
