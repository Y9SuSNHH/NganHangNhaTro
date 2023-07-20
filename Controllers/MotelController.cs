using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using NganHangNhaTro.Models.Views;
using Microsoft.AspNetCore.Authorization;
using NganHangNhaTro.Repositories;
using NganHangNhaTro.Services;
using NganHangNhaTro.Models;
using NganHangNhaTro.Helpers;


namespace NganHangNhaTro.Controllers
{
    public class MotelController : Controller
    {
        private string name = "motel";
        private readonly IMotelRepository _motelRepository;

        private readonly IPhotoService _photoService;

        public MotelController(IMotelRepository motelRepository, IPhotoService photoService)
        {
            _motelRepository = motelRepository;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(MotelView motelView)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Có lỗi xảy ra, vui lòng thử lại";
            }
            else
            {
                string imagePath = await _photoService.add(motelView.image);

                if (imagePath == "")
                {
                    ViewBag.ErrorMessage = "Photo upload empty";
                }
                Motel motel = new Motel
                {
                    title = motelView.title,
                    description = motelView.description,
                    detail = motelView.detail,
                    address = motelView.address,
                    price = motelView.price,
                    image = imagePath,
                    created_by = 1,
                };

                await _motelRepository.add(motel);

                List<dynamic> array = new List<dynamic>();
                return Ok(new {
                    success = true,
                    data = array,
                    errors = array,
                });
            }

            return View(motelView);
        }
    }
}
