using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;


namespace NganHangNhaTro.Services
{
    public interface IPhotoService
    {
        public Task<string> add(IFormFile file);
        // public Task<ImageUploadResult> addPhotoAsync(IFormFile file);
        // public Task<DeletionResult> deletePhotoAsync(string publicUrl);
    }
}