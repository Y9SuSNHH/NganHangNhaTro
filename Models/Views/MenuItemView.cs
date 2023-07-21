using System.ComponentModel.DataAnnotations;

namespace NganHangNhaTro.Models.Views
{
    public class MenuItemView
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}