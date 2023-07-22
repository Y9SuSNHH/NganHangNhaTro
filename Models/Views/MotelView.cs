using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;

namespace NganHangNhaTro.Models.Views
{
    public class MotelView
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Tài khoản không được bỏ trống")]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public string detail { get; set; }

        [Required]
        public string address { get; set; }

        [Required]
        public string price { get; set; }

        //[Required]
        public string image { get; set; }

        [Required]
        public int created_by { get; set; }

        [Required]
        public IFormFile file { get; set; }

        // Giá điện nước
        //[Required]
        //public string priceElectronicWater { get; set; }

        //// Diện tích
        //[Required]
        //public int acreage { get; set; }

        // Trạng thái
        [Required]
        public bool status { get; set; }

        //// Ngày đăng
        //[Required]
        //public DateTime post { get; set; }

        // Ngày đăng
        public DateTime created_at { get; set; }
    }
}