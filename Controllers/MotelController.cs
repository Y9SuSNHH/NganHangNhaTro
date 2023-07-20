﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly IPhotoService _photoService;

        public MotelController(IMotelRepository motelRepository, IWebHostEnvironment env, IPhotoService photoService)
        {
            _motelRepository = motelRepository;
            _photoService = photoService;
            _env = env;
        }

        public IActionResult Index()
        {
            int uid = int.Parse(HttpContext.Session.GetString("uid"));
            List<Motel> motels = _motelRepository.getAllWithCreatedBy(uid);
            return View(motels);
        }

        public IActionResult Detail(int id)
        {
            Motel motel = _motelRepository.show(id);
            return View(motel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(MotelView motelView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ErrorMessage = "Có lỗi xảy ra, vui lòng thử lại";
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Danger, "Unknown error");
                }
                else
                {
                    // Lưu ảnh vào thư mục
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
                        status = motelView.status,
                        created_by = int.Parse(HttpContext.Session.GetString("uid")),
                        created_at = DateTime.Now,
                    };

                    _motelRepository.add(motel);
                    ViewBag.Alert = CommonServices.ShowAlert(Alerts.Success, "Motel added");

                    return Ok(new
                    {
                        success = true,
                        data = motel,
                        errors = new List<dynamic>(),
                    });
                }
                return View("Create");

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("Create");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Motel motel = _motelRepository.show(id);
            return View(motel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(MotelView motelView)
        {
            if (ModelState.IsValid)
            {
                Motel motel = new Motel
                {
                    title = motelView.title,
                    description = motelView.description,
                    detail = motelView.detail,
                    address = motelView.address,
                    price = motelView.price,
                    status = motelView.status,
                };
                _motelRepository.save(motel);
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _motelRepository.destroy(id);
            return RedirectToAction("Index");
        }

    }
}
