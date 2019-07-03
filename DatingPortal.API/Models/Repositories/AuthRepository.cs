using System.Linq;
using System.Threading.Tasks;
using DatingPortal.API.Data;
using DatingPortal.API.Models.Iterfaces;
using Microsoft.EntityFrameworkCore;

namespace DatingPortal.API.Models.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext context;

        public AuthRepository(DataContext context)
        {
            this.context = context;
        }
        public async Task<User> Login(string username, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!PasswordHashSalt.VerificationPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordSalt;
            byte[] passwordHash;

            PasswordHashSalt.CreatePasswordHashSalt(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            bool userExists = await context.Users.AnyAsync(x => x.Username == username);

            if (userExists)
                return true;

            return false;
        }
    }
}