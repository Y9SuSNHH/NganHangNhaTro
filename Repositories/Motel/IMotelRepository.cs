using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;


namespace NganHangNhaTro.Repositories
{
    public interface IMotelRepository
    {

        // public User Add(User user);

        // public void SaveChanges();
        // Add other member-related methods as needed

        public List<Motel> GetMotelList();
        // Thêm phòng trọ mới
        public Motel NewMotel(MotelView motelView);
        // Cập nhật thông tin phòng trọ
        public MotelView EditMotel(int Id);
        // Xóa phòng trọ
        public void DeleteMotel(int Id);
        // Tìm kiếm phòng theo chuỗi thông tin truyền vào
        public List<Motel> SearchMotelByString(string infoSearch);
    }
}