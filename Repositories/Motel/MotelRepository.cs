using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;
using Microsoft.EntityFrameworkCore;


namespace NganHangNhaTro.Repositories
{
    public class MotelRepository : IMotelRepository
    {
        private readonly dbContext _dbContext;

        public MotelRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> add(Motel motel)
        {
            try
            {
                if (motel != null)
                {
                    _dbContext.Motel.Add(motel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}