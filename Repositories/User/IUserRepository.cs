using Microsoft.EntityFrameworkCore;
using NganHangNhaTro.Models;
using NganHangNhaTro.Models.Views;


namespace NganHangNhaTro.Repositories
{
    public interface IUserRepository
    {
        public User getByUsernameAndPassword(LoginView login);


        public Task<bool> create(RegisterView register);

		// public User Add(User user);

		// public void SaveChanges();
		// Add other member-related methods as needed

		public User getUserById(int id);

	}
}