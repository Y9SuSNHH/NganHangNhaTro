using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NganHangNhaTro.Models
{
    [Table("motels")]
    public partial class Motel
    {
        // Id
        [Key]
        public int id { get; set; }
        
        // Tiêu đề
        [Required]
        public string title { get; set; }

        // Mô tả
        [Required]
        public string description { get; set; }

        // Chi tiết
        [Required]
        public string detail { get; set; }

        // Địa chỉ
        [Required]
        public string address { get; set; }

        // Giá phòng
        [Required]
        public string price { get; set; }

        // Ảnh
        [Required]
        public string image { get; set; }

        // Người tạo phòng
        [Required]
        public int created_by { get; set; }

        //// Giá điện nước
        //[Required]
        //public string priceElectronicWater { get; set; }

        //// Diện tích
        //[Required]
        //public int acreage { get; set; }

        // Trạng thái
        [Required]
        public bool status { get; set; }

        // Ngày đăng
        //[Required]
        //public DateTime post { get; set; }

        // Ngày đăng
        public DateTime created_at { get; set; }
    }
}
