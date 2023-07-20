using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;


namespace NganHangNhaTro.Repositories
{
    public interface IMotelRepository
    {
        public Task<bool> add(Motel motel);

        // public User Add(User user);

        // public void SaveChanges();
        // Add other member-related methods as needed
    }
}