using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;
using Microsoft.EntityFrameworkCore;


namespace NganHangNhaTro.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly dbContext _dbContext;

        public UserRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User getByUsernameAndPassword(LoginView login)
        {
            var user = _dbContext.User.SingleOrDefault(user => user.username == login.username && user.password == login.password);
            Console.WriteLine(user);
            return user;
        }

        public async Task<bool> add(RegisterView register)
        {
            try
            {
                if (register != null)
                {
                    var user = new User()
                    {
                        username = register.username,
                        email = register.email,
                        phone_number = register.phone_number,
                        password = register.password,
                    };
                    _dbContext.User.Add(user);
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