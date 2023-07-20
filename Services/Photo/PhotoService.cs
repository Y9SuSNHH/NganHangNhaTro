using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NganHangNhaTro.Helpers;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;

namespace NganHangNhaTro.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IWebHostEnvironment _enviroment;

        // private readonly Cloudinary _cloundinary;

        public PhotoService(IWebHostEnvironment environment)
        {
            _enviroment = environment;
        }

        public async Task<string> add(IFormFile file)
        {
            if (file.Length > 0)
            {
                string wwwPath = this._enviroment.WebRootPath;
                string folderName = "images";
                string path = Path.Combine(wwwPath, folderName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // var uploadedFiles = new Dictionary<string, string>();

                string fileName = string.Format("{0}-{1}", Guid.NewGuid(), file.FileName);

                var savePath = Path.Combine(path, fileName);

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                    // uploadedFiles.Add(fileName, fileName);
                }
                return $"/{folderName}/{fileName}";
            }

            return "";
        }

        // public async Task<DeletionResult> deletePhotoAsync(string publicUrl)
        // {
        //     var publicId = publicUrl.Split('/').Last().Split('.')[0];
        //     var deleteParams = new DeletionParams(publicId);
        //     return await _cloundinary.DestroyAsync(deleteParams);
        // }
    }
}