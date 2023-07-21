using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using NganHangNhaTro.Models.Views;
using Microsoft.AspNetCore.Authorization;
using NganHangNhaTro.Repositories;
using NganHangNhaTro.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using NganHangNhaTro.Enums;
using NganHangNhaTro.Services;

namespace NganHangNhaTro.Controllers
{
    public class MotelController : Controller
    {
        private string name = "motel";
        private IMotelRepository _motelRepository;
        private readonly IWebHostEnvironment _env;

        public MotelController(IMotelRepository motelRepository, IWebHostEnvironment env)
        {
            _motelRepository = motelRepository;
            _env = env;
        }

        public IActionResult Index()
        {
            List<Motel> motels = _motelRepository.GetMotelList();
            return View(motels);
        }

        // Chi tiết thông tin motel
        public IActionResult Detail(int id)
        {
            Motel motel = _motelRepository.GetMotelList().Where(m => m.id == id).FirstOrDefault(); ;
            return View(motel);
        }

        public IActionResult Create()
        {
            return View();
        }

        // Tạo một motel mới
        [HttpPost]
        public async Task<IActionResult> Create(MotelView motel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Lưu ảnh vào thư mục
                    string uploadPath = Path.Combine(_env.WebRootPath, "app-assets", "images", "data");
                    string filePath = Path.Combine(uploadPath, motel.file.FileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        motel.file.CopyTo(fileStream);
                    }

                    _motelRepository.NewMotel(motel);
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Motel added");
                    return View("Create");
                }
                else
                {
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                    return View();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        // Hiển thị giao diện motel
        [HttpGet]
        public ActionResult Edit(int id)
        {
            MotelView motel = _motelRepository.EditMotel(id);
            return View(motel);
        }

        // Sửa thông tin motel
        [HttpPost]
        public ActionResult EditMotel(MotelView motelEdit)
        {
            if (ModelState.IsValid)
            {
                _motelRepository.DeleteMotel(motelEdit.id);
                _motelRepository.NewMotel(motelEdit);
                return RedirectToAction("Index");

            }
            return View();
        }

        // Xóa Motel theo id
        public IActionResult Delete(int id)
        {
            _motelRepository.DeleteMotel(id);
            return RedirectToAction("Index");
        }

        // Tìm kiếm thông tin motel theo chuỗi thông tin truyền vào
        public IActionResult SearchMotelByString(string infoSearch)
        {
            return Json(_motelRepository.SearchMotelByString(infoSearch).ToList());
        }

    }
}
