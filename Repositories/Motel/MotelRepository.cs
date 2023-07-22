using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Razor;

namespace NganHangNhaTro.Repositories
{
    public class MotelRepository : IMotelRepository
    {
        private readonly dbContext _dbContext;

        public MotelRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy toàn bộ danh sách phòng trọ
        public List<Motel> GetMotelList()
        {
            return _dbContext.Motel.ToList();
        }

        // Tạo mới một phòng trọ
        public Motel NewMotel(MotelView motelView)
        {
            Motel motel = new Motel();
            motel.title = motelView.title;
            motel.description = motelView.description;
            motel.address = motelView.address;
            motel.price = motelView.price;
            // Lấy đường dẫn của ảnh
            motel.image = "/app-assets/images/data/" + motelView.file.FileName;
            motel.detail = motelView.detail;
            motel.created_by = motelView.created_by;
            //motel.priceElectronicWater = motelView.priceElectronicWater;
            //motel.acreage = motelView.acreage;
            motel.status = motelView.status;
            motel.created_at = DateTime.Now;
            //motel.post = motelView.post;
            // Lưu thông tin motel
            _dbContext.Motel.Add(motel);

            _dbContext.SaveChanges();
            return motel;
        }

        // Tìm thông tin phòng trọ theo id để thực hiện sử thông tin phòng theo id
        public MotelView EditMotel(int id)
        {
            // Tìm thông tin phòng trọ theo id từ client truyền vào
            Motel motel = _dbContext.Motel.Find(id);
            // Chuyển thông tin tìm được từ server lên client
            MotelView motelView = new MotelView();
            motelView.id = id;
            motelView.title = motel.title;
            motelView.description = motel.description;
            motelView.address = motel.address;
            motelView.price = motel.price;
            motelView.detail = motel.detail;
            motelView.image = motel.image;
            return motelView;
        }

        // Xóa phòng trọ
        public void DeleteMotel(int id)
        {
            Motel motel = _dbContext.Motel.Find(id);
            _dbContext.Motel.Remove(motel);
            _dbContext.SaveChanges();
        }

        //Thực hiện tìm kiếm theo chuỗi truyền vào
        public List<Motel> SearchMotelByString(string infoSearch)
        {
            var searchResult = _dbContext.Motel.Where(
                    motel =>
                    motel.title.ToLower().Contains(infoSearch.ToLower()) ||
                    motel.address.ToLower().Contains(infoSearch.ToLower()) ||
                    motel.price.Contains(infoSearch.ToLower()) ||
                    motel.detail.Contains(infoSearch.ToLower()) //||
                    //motel.priceElectronicWater.Contains(infoSearch.ToLower()) ||
                    //motel.acreage.ToString().Contains(infoSearch.ToLower())
                ).ToList();
            return searchResult;
            //return null;
        }

        // Thực hiện phân trang
        public List<Motel> GetMotelPage(int page, int pageSize)
        {
            // Tính toán vị trí bắt đầu và số lượng mục cần lấy
            int skipItems = (page - 1) * pageSize;

            // Lấy danh sách các mục từ nguồn dữ liệu, ví dụ: từ cơ sở dữ liệu
            // Dùng phương thức Skip() và Take() để chọn trang phù hợp
            List<Motel> motels = _dbContext.Motel
                .OrderBy(m => m.price) // Sắp xếp theo một trường nào đó (ví dụ: theo Id)
                .Skip(skipItems)    // Bỏ qua các mục ở trang trước đó
                .Take(pageSize)     // Lấy số lượng mục cho trang hiện tại
                .ToList();

            return motels;
        }
    }
}